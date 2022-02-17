using Proxying;
using System;
using System.Reflection;

static class EchoProxy
{
	public static object CreateFor(object original)
	{
		Type t = original.GetType();

		InvocationHandler ih = delegate(object proxy, MemberInfo method, object[] arguments)
		{
			Console.WriteLine(">> Invoking {0} method of {1} class", method.Name, t.Name);
			return method.Invoke(original, arguments);
		};

		return Proxy.NewProxyInstance(t.GetInterfaces(), ih);
	}
}

static class Test
{
	public static void Main()
	{
		IGreeter g = new EnglishGreeter();
		IGreeter gp = (IGreeter)EchoProxy.CreateFor(g);

		Console.WriteLine(gp.Meet("Jack", 16));
		Console.WriteLine(gp.Leave("Jack"));
	}
}
