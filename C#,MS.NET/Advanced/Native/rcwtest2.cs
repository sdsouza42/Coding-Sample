using QuadEq;
using System;
using System.Runtime.InteropServices;

[ComImport]
[Guid("204961C4-291C-4698-A77F-BFA2250778C6")]
class QuadraticEquationClass {}

static class Program
{
	[STAThread]
	public static void Main()
	{
		Console.Write("Perimeter: ");
		double perim = Convert.ToDouble(Console.ReadLine());
		Console.Write("Area     : ");
		double area = Convert.ToDouble(Console.ReadLine());
		double a = 1, b = -perim / 2, c = area;

		IEquation rcw = (IEquation)new QuadraticEquationClass();

		if(rcw.HasRealRoots(a, b, c) != 0)
		{
			double r1, r2;
			rcw.Solve(a, b, c, out r1, out r2);
			Console.WriteLine("Dimensions: {0}, {1}", r1, r2);
		}
		else
			Console.WriteLine("No such rectangle!");
	}
}
