using Payroll;
using System;

static class Program
{
	private static double GetAverageIncome(Employee[] group)
	{
		double sum = 0;

		foreach(Employee member in group)
			sum += member.GetNetIncome();

		return sum / group.Length;
	}

	private static double GetTotalBonus(Employee[] group)
	{
		double sum = 0;

		foreach(Employee member in group)
		{
			if(member is SalesPerson)
				sum += 0.04 * member.GetNetIncome();
			else
				sum += 0.06 * member.GetNetIncome();
		}

		return sum;
	}

	private static double GetTotalSales(Employee[] group)
	{
		double sum = 0;

		foreach(Employee member in group)
		{
			SalesPerson sp = member as SalesPerson;
			if(sp != null) sum += sp.Sales;
		}

		return sum;
	}


	public static void Main()
	{
		Employee[] dept = new Employee[5];
		dept[0] = new Employee(186, 52);
		dept[1] = new Employee(190, 110);
		dept[2] = new SalesPerson(195, 45, 65000);
		dept[3] = new Employee(170, 200);
		dept[4] = new SalesPerson(165, 55, 35000);

		Console.WriteLine("Average Income: {0:0.00}", GetAverageIncome(dept));
		Console.WriteLine("Total Bonus   : {0:0.00}", GetTotalBonus(dept));
		Console.WriteLine("Total Sales   : {0:0.00}", GetTotalSales(dept));

	}
}	