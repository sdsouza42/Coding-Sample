using System;
using System.Reflection;

static class Program
{
	public static void Main(string[] args)
	{
		double p = Convert.ToDouble(args[0]);
		Type t = Type.GetType(args[1], true);
		object pol = Activator.CreateInstance(t);
		int m = 10;

		for(int n = 1; n <= m; ++n)
		{
			double emi;
			float r = (float)t.InvokeMember(args[2], BindingFlags.InvokeMethod, null, pol, new object[]{p, n});

			emi = p * Math.Pow(1 + r / 100, n) / (12 * n);

			Console.WriteLine("{0}\t{1:0.00}", n, emi); 
		}
	}	
}
