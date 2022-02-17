using System;
using System.Reflection;
using System.Dynamic;

class Greeter
{
	public string Greet(string person)
	{
		return "Hello " + person;
	}
}

class Actor : DynamicObject
{
	public string Greet(string person)
	{
		return "Greetings " + person;
	}

	public override bool TryInvokeMember(InvokeMemberBinder binder, object[] arguments, out object result)
	{
		if(arguments.Length == 1)
		{
			result = binder.Name + "ing " + arguments[0];
			return true;
		}

		result = null;
		return false;
	}
}

static class Program
{
	public static void Main(string[] args)
	{
		//CLR binding
		//object target = Activator.CreateInstance(Type.GetType(args[0]));
		//Console.WriteLine(target.GetType().InvokeMember("Greet", BindingFlags.InvokeMethod, null, target, new[]{"World"}));

		//DLR binding
		dynamic target = Activator.CreateInstance(Type.GetType(args[0]));
		Console.WriteLine(target.Greet("World"));
		Console.WriteLine(target.Help("World"));
		Console.WriteLine(target.Destroy("World"));
	}
}
