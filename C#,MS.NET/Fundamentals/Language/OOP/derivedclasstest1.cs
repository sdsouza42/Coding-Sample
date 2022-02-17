using Payroll;
using System;

static class Program
{
	//Extension method of Employee
	//must be a member of a static class
	//first parameter must be of the type being extended declared with 'this' qualifier
	private static double GetIncomeTax(this Employee emp)
	{
		double i = emp.GetNetIncome();

		return i > 10000 ? 0.15 * (i - 10000) : 0;
	}

	public static void Main()
	{
		Employee jack = new Employee();
		jack.Hours = 186;
		jack.Rate = 52;
		Console.WriteLine("Jack's ID is {0}, Income is {1:0.00} and Tax is {2:0.00}", jack.Id, jack.GetNetIncome(), jack.GetIncomeTax());

		SalesPerson jill = new SalesPerson(186, 52, 64000);
		Console.WriteLine("Jill's ID is {0}, Income is {1:0.00} and Tax is {2:0.00}", jill.Id, jill.GetNetIncome(), jill.GetIncomeTax());

		Console.WriteLine("Number of Employees: {0}", Employee.CountInstances());
	}
}
