using Banking;
using System;

static class Program
{
	public static void Main(string[] args)
	{
		Account jack = Banker.OpenCurrentAccount();
		jack.Deposit(15000);

		Account jill = Banker.OpenSavingsAccount();
		jill.Deposit(10000);

		double amt = double.Parse(args[0]);
		try
		{
			jill.Transfer(amt, jack);
		}
		catch(AccountingException ex) when(ex.Cause == FaultType.InsufficientFunds)
		{
			Console.WriteLine("Transfer failed due to lack of funds!");
		}

		Console.WriteLine("Jack's Account ID is {0} and Balance is {1:0.00}", jack.Id, jack.Balance);
		Console.WriteLine("Jill's Account ID is {0} and Balance is {1:0.00}", jill.Id, jill.Balance);
	}
}
