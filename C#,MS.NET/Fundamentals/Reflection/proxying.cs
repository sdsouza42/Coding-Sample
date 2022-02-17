using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Proxying
{
	public delegate object InvocationHandler(object proxy, MemberInfo method, object[] arguments);

	public static class Proxy
	{
		public static object NewProxyInstance(Type[] interfaces, InvocationHandler handler)
		{
			AssemblyName assemblyName = new AssemblyName();
			assemblyName.Name = "Proxy$" + Guid.NewGuid();

			//create a new in-memory assembly with above name in the current app-domain
			AssemblyBuilder assemblyBuilder = 
				AppDomain.CurrentDomain.DefineDynamicAssembly(
				assemblyName, 
				AssemblyBuilderAccess.Run);
			
			//add a new module in the above assembly
			ModuleBuilder moduleBuilder = 
				assemblyBuilder.DefineDynamicModule(assemblyName.Name, true);

			//define the proxy class called ProxyImpl in the above module
			TypeBuilder typeBuilder = moduleBuilder.DefineType(
				 "ProxyImpl", TypeAttributes.Public|TypeAttributes.Class, null, interfaces);

			//define a field in the above proxy class to hold the InvocationHandler
			FieldBuilder handlerField = GenerateField(typeBuilder);

			//define a constructor in the above proxy class to initialize above handler field
			GenerateConstructor(typeBuilder, handlerField);
			
			//make the above proxy class implement specified interfaces to invoke the handler
			GenerateInterfaceImplementation(typeBuilder, interfaces, handlerField);

			//create the above proxy class type and return its instance
			Type generatedType = typeBuilder.CreateType();
			return Activator.CreateInstance(generatedType, new object[]{handler});
		}

		private static void GenerateInterfaceImplementation(TypeBuilder typeBuilder, 
			Type[] interfaces, FieldBuilder handlerField)
		{
			foreach(Type iface in interfaces)
				GenerateInterfaceImplementation(typeBuilder, iface, handlerField);
		}

		private static void GenerateInterfaceImplementation(TypeBuilder typeBuilder, 
			Type iface, FieldBuilder handlerField)
		{
			Type[] baseInterfaces = iface.GetInterfaces(); 
			GenerateInterfaceImplementation(typeBuilder, baseInterfaces, handlerField);

			MethodInfo[] methods = iface.GetMethods();
			foreach(MethodInfo method in methods)
				GenerateMethodImplementation(typeBuilder, method, handlerField, iface);
		}

		private static FieldBuilder GenerateField(TypeBuilder typeBuilder)
		{
			return typeBuilder.DefineField("handler", 
				typeof(InvocationHandler), FieldAttributes.Public);
		}


		private static ConstructorBuilder GenerateConstructor(
			TypeBuilder typeBuilder, FieldBuilder handlerField)
		{
			ConstructorBuilder ctorBuilder = typeBuilder.DefineConstructor(
				MethodAttributes.Public, 
				CallingConventions.Standard, 
				new Type[] { typeof(InvocationHandler) });
			
			ILGenerator gen = ctorBuilder.GetILGenerator();
			gen.Emit(OpCodes.Ldarg_0);
			gen.Emit(OpCodes.Call, typeof(Object).GetConstructor(new Type[0]));
			gen.Emit(OpCodes.Ldarg_0);
			gen.Emit(OpCodes.Ldarg_1);
			gen.Emit(OpCodes.Stfld, handlerField);
			gen.Emit(OpCodes.Ret);

			return ctorBuilder;
		}


		private static void GenerateMethodImplementation(
			TypeBuilder typeBuilder, MethodInfo method, 
			FieldBuilder handlerField, Type iface)
		{
			ParameterInfo[] parameterInfo = method.GetParameters();

			System.Type[] parameters = new System.Type[parameterInfo.Length];
			
			for(int i = 0; i < parameterInfo.Length; ++i)
				parameters[i] = parameterInfo[i].ParameterType;

			MethodAttributes atts = MethodAttributes.Public|MethodAttributes.Virtual;

			MethodBuilder methodBuilder = 
				typeBuilder.DefineMethod(method.Name, atts, CallingConventions.Standard, 
				method.ReturnType, parameters);

			WriteILForMethod(methodBuilder, parameters, handlerField);
		}

		private static void WriteILForMethod(MethodBuilder builder, 
			System.Type[] parameters, FieldBuilder handlerField)
		{
			int arrayPositionInStack = 1;

			ILGenerator gen = builder.GetILGenerator();

			gen.DeclareLocal(typeof(MethodBase));

			if(builder.ReturnType != typeof(void))
			{
				gen.DeclareLocal(builder.ReturnType);
				arrayPositionInStack = 2;
			}

			gen.DeclareLocal(typeof(object[]));
			gen.Emit(OpCodes.Call, typeof(MethodBase).GetMethod("GetCurrentMethod"));
			gen.Emit(OpCodes.Stloc_0);
			gen.Emit(OpCodes.Ldarg_0);
			gen.Emit(OpCodes.Ldfld, handlerField);
			gen.Emit(OpCodes.Ldarg_0);
			gen.Emit(OpCodes.Ldloc_0);
			gen.Emit(OpCodes.Ldc_I4, parameters.Length);
			gen.Emit(OpCodes.Newarr, typeof(object));

			if(parameters.Length != 0)
			{
				gen.Emit(OpCodes.Stloc, arrayPositionInStack);
				gen.Emit(OpCodes.Ldloc, arrayPositionInStack);
			}

			for(int c = 0; c < parameters.Length; ++c)
			{
				gen.Emit(OpCodes.Ldc_I4, c);
				gen.Emit(OpCodes.Ldarg, c+1);

				if(parameters[c].IsValueType)
					gen.Emit(OpCodes.Box, parameters[c].UnderlyingSystemType);

				gen.Emit(OpCodes.Stelem_Ref);
				gen.Emit(OpCodes.Ldloc, arrayPositionInStack);
			}

			gen.Emit(OpCodes.Callvirt, typeof(InvocationHandler).GetMethod("Invoke"));

			if(builder.ReturnType != typeof(void))
			{
				if(builder.ReturnType.IsValueType)
					gen.Emit(OpCodes.Unbox_Any, builder.ReturnType);
				else
					gen.Emit(OpCodes.Castclass, builder.ReturnType);

				gen.Emit(OpCodes.Stloc, 1);

				Label label = gen.DefineLabel();
				gen.Emit(OpCodes.Br_S, label);
				gen.MarkLabel(label);
				gen.Emit(OpCodes.Ldloc, 1);
			}
			else
				gen.Emit(OpCodes.Pop);

			gen.Emit(OpCodes.Ret);
		}

		//helper method for redirecting invocation of proxy member to another object
		public static object Invoke(this MemberInfo member, object target, object[] arguments)
		{
			return target.GetType().InvokeMember(member.Name, BindingFlags.InvokeMethod, null, target, arguments);
		}

	}
}
