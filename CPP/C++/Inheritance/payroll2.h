#ifndef PAYROLL2_H
#define PAYROLL2_H

#include <iostream>

namespace Payroll
{
	class Employee
	{
	public:
		explicit Employee(long h=0, float r=0)
		{
			hours = h;
			rate = r;
			#ifdef _TESTING
			std::cout << "Employee object created" << std::endl;
			#endif
		}

		long GetHours() const
		{
			return hours;
		}

		void SetHours(long value)
		{
			hours = value;
		}

		float GetRate() const
		{
			return rate;
		}

		void SetRate(float value)
		{
			rate = value;
		}
	
		//overridable method
		virtual double GetNetIncome() const
		{
			double income = hours * rate;
			long ot = hours - 180;

			if(ot > 0)
				income += 50 * ot;

			return income;
		}

		virtual ~Employee()
		{
			#ifdef _TESTING
			std::cout << "Employee object destroyed" << std::endl;
			#endif
		}

	private:
		long hours;
		float rate;
	};

	//derived class of Employee
	class SalesPerson : public Employee
	{
	public:
		SalesPerson(long h, float r, double s) : Employee(h, r)
		{
			sales = s;
			#ifdef _TESTING
			std::cout << "SalesPerson object created" << std::endl;
			#endif
		}

		virtual double GetSales() const
		{
			return sales;
		}

		void SetSales(double value)
		{
			sales = value;
		}

		//method overriding : implimenting virtual method of base-class 
		//		      in the derived class with same parameter types
		double GetNetIncome() const
		{
			double income = Employee::GetNetIncome();

			if(sales >= 20000)
				income += 0.05 * sales;

			return income;
		}

		~SalesPerson()
		{
			#ifdef _TESTING
			std::cout << "SalesPerson object destroyed" << std::endl;
			#endif
		}
	private:
		double sales;
	};
}


#endif

