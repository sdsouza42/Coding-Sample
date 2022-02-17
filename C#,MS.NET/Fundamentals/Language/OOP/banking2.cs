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

	public interface IProfitable
	{
		double AddInterest(int period);
	}

	public interface ITaxable
	{
		void Deduct();
	}

	public interface IFineable
	{
		void Deduct();
	}

	sealed class CurrentAccount : Account, ITaxable, IFineable
	{
		public override void Deposit(double amount)
		{
			base.Balance += amount;
		}

		public override void Withdraw(double amount)
		{
			base.Balance -= amount;
		}

		//explicit interface implementation
		void ITaxable.Deduct()
		{
			double extra = base.Balance - 25000;
			if(extra > 0)
				base.Balance -= 0.05 * extra;
		}

		void IFineable.Deduct()
		{
			if(base.Balance < 0)
				base.Balance *= 1.1;
		}
	}

	sealed class SavingsAccount : Account, IProfitable
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

		public double AddInterest(int period)
		{
			float rate = Balance < 2 * MinBalance ? 4 : 5;
			double interest = Balance * period * rate / 100;

			Balance += interest;

			return interest;
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
