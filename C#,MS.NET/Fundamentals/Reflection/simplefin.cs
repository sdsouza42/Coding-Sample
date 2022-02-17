using System;

namespace Finance
{
	
	public interface ILoanPolicy
	{
		float GetInterestRate(double amount, int period);
	}

	public class HomeLoan : ILoanPolicy
	{

		public float GetInterestRate(double amount, int period)
		{
			return (period < 5) ? 7 : 8;
		}

	}

	public class EducationLoan : ILoanPolicy
	{

		public float GetInterestRate(double amount, int period)
		{
			return 6;
		}

	}

	public class PersonalLoan : ILoanPolicy
	{

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
