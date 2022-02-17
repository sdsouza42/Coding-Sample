using Banking;
using System;

static class Program
{
	private static void PayAnnualInterest(Account[] accounts)
	{
		foreach(Account acc in accounts)
		{
			IProfitable p = acc as IProfitable;
			p?.AddInterest(1); //if(p != null) p.AddInterest(1)
		}
	}

	private static void DeductTax(Account[] accounts)
	{
		foreach(Account acc in accounts)
		{
			ITaxable t = acc as ITaxable;
			t?.Deduct();
		}
	}

	public static void Main()
	{
		Account[] bank = new Account[4];
		bank[0] = Banker.OpenCurrentAccount();
		bank[0].Deposit(20000);
		bank[1] = Banker.OpenSavingsAccount();
		bank[1].Deposit(25000);
		bank[2] = Banker.OpenSavingsAccount();
		bank[2].Deposit(35000);
		bank[3] = Banker.OpenCurrentAccount();
		bank[3].Deposit(50000);

		PayAnnualInterest(bank);
		DeductTax(bank);

		foreach(Account acc in bank)
			Console.WriteLine("{0}\t{1:0.00}", acc.Id, acc.Balance);
	}
}
