using System;
using System.Runtime.InteropServices;

static class Program
{
	[StructLayout(LayoutKind.Sequential)]
	struct FixedDeposit
	{
		public int Id;
		public double Amount;
		public int Period;
	}

	[DllImport(@"legacy\x86\invest.dll", CallingConvention=CallingConvention.Cdecl)]
	private extern static int InitFixedDeposit(double amount, int period, out FixedDeposit fd);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	delegate float Scheme(int period);

	[DllImport(@"legacy\x86\invest.dll", CallingConvention=CallingConvention.Cdecl)]
	private extern static double GetMaturityValue(ref FixedDeposit fd, Scheme policy);

	public static void Main()
	{
		Console.Write("Amount: ");
		double amt = Convert.ToDouble(Console.ReadLine());
		Console.Write("Period: ");
		int prd = Convert.ToInt32(Console.ReadLine());

		FixedDeposit fd;
		InitFixedDeposit(amt, prd, out fd);
		double mv = GetMaturityValue(ref fd, n => n < 3 ? 7 : 8);
		Console.WriteLine("Fixed-deposit ID is {0} and maturity-value is {1:0.00}", fd.Id, mv);
	}
}
