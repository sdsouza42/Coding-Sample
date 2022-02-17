using System;

namespace Banking
{
	public enum FaultType {InsufficientFunds, IllegalTransfer}

	public class AccountingException : ApplicationException
	{
		public FaultType Cause {get;}

		public AccountingException(FaultType fault) : base(fault.ToString())
		{
			this.Cause = fault;
		}
	}

	public abstract class Account
	{
		public string Id {get; internal set;}

		public double Balance {get; protected set;}

		public abstract void Deposit(double amount);

		public abstract void Withdraw(double amount);

		public void Transfer(double amount, Account that)
		{
			if(ReferenceEquals(this, that))
				throw new AccountingException(FaultType.IllegalTransfer);

			this.Withdraw(amount);
			that.Deposit(amount);
		}
	}

	sealed class CurrentAccount : Account
	{
		public override void Deposit(double amount)
		{
			base.Balance += amount;
		}

		public override void Withdraw(double amount)
		{
			base.Balance -= amount;
		}
	}

	sealed class SavingsAccount : Account
	{
		const double MinBalance = 5000;

		internal SavingsAccount()
		{
			base.Balance = MinBalance;
		}

		public override void Deposit(double amount)
		{
			base.Balance += amount;
		}

		public override void Withdraw(double amount)
		{
			if(base.Balance - amount < MinBalance)
				throw new AccountingException(FaultType.InsufficientFunds);

			base.Balance -= amount;
		}
	}

	public static class Banker
	{
		private static int nid = Environment.TickCount % 1000000;

		public static Account OpenCurrentAccount()
		{
			CurrentAccount acc = new CurrentAccount();

			acc.Id = "C/A" + nid++;

			return acc;
		}

		public static Account OpenSavingsAccount()
		{
			SavingsAccount acc = new SavingsAccount();

			acc.Id = "S/A" + nid++;

			return acc;
		}
	}
}
