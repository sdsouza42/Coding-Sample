using Finance;
using System;
using System.Reflection;

static class Program
{
	public static void Main(string[] args)
	{
		double p = Convert.ToDouble(args[0]);
		Type t = Type.GetType(args[1], true);
		bool rb = t.IsDefined(typeof(ReducingBalanceAttribute), false);
		object pol = Activator.CreateInstance(t);
		MethodInfo meth = t.GetMethod(args[2], new Type[]{typeof(double), typeof(int)});
		MaxDurationAttribute md = (MaxDurationAttribute)Attribute.GetCustomAttribute(meth, typeof(MaxDurationAttribute));
		int m = (md != null) ? md.Limit : 10;

		for(int n = 1; n <= m; ++n)
		{
			double emi;
			float r = (float)meth.Invoke(pol, new object[]{p, n});

			if(rb)
			{
				float i = r / 1200;
				emi = p * i / (1 - Math.Pow(1 + i, -12 * n));
			}
			else
				emi = p * Math.Pow(1 + r / 100, n) / (12 * n);

			Console.WriteLine("{0}\t{1:0.00}", n, emi); 
		}

		if(rb)
			Console.WriteLine("Using reducing-balance method.");
	}	
}
