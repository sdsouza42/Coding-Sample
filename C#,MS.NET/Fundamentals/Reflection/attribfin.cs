using System;

namespace Finance
{
	[AttributeUsage(AttributeTargets.Class)]
	public class ReducingBalanceAttribute : Attribute {}

	[AttributeUsage(AttributeTargets.Method)]
	public class MaxDurationAttribute : Attribute
	{
		public int Limit {get; set;}

		public MaxDurationAttribute(int value)
		{
			this.Limit = value;
		}

		public MaxDurationAttribute() : this(5) {}
		
	}
	
	public interface ILoanPolicy
	{
		float GetInterestRate(double amount, int period);
	}

	[ReducingBalance]
	public class HomeLoan : ILoanPolicy
	{
		
		[MaxDuration(15)]
		public float GetInterestRate(double amount, int period)
		{
			return (period < 5) ? 7 : 8;
		}

	}

	[Serializable]
	public class EducationLoan : ILoanPolicy
	{
		[MaxDuration]
		public float GetInterestRate(double amount, int period)
		{
			return 6;
		}

	}

	[ReducingBalance]
	public class PersonalLoan : ILoanPolicy
	{
		[MaxDuration(Limit=4)]	
		public float GetInterestRate(double amount, int period)
		{
			return (amount < 50000) ? 8 : 9;
		}

		public float GetInterestRateForEmployees(double amount, int period)
		{
			return (amount < 100000) ? 4 : 5;			
		}
	}

	public class BusinessLoan
	{

		public float RateOfInterest(double amount, int period)
		{
			float r = (amount < 10000) ? 9 : 10;
			if(period > 2) r += 1;
			return r;
		}

	}

}
