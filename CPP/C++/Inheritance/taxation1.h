#ifndef TAXATION1_H
#define TAXATION1_H

#include <iostream>

namespace Taxation
{
	class TaxPayer
	{
	public:
		long PIN() const
		{
			return pin;
		}

		virtual double AnnualIncome() const = 0;

		double Tax() const
		{
			double taxable = AnnualIncome() - 120000;

			return taxable > 0 ? 0.15 * taxable : 0;
		}

		static int Count()
		{
			return count;
		}

		virtual ~TaxPayer()
		{
			count--;
		}
	protected:
		TaxPayer(long pn)
		{
			pin = pn;
			++count;
		}
	private:
		long pin;
		static int count;
	};

	int TaxPayer::count = 0;

	std::ostream& operator<<(std::ostream& out, const TaxPayer& value)
	{
		out << "P.I.N is "
		    << value.PIN()
		    << " and Tax is "
		    << value.Tax();

		return out;
	}

	class Employee : public TaxPayer
	{
	public:
		Employee(long pn, double sy) : TaxPayer(pn)
		{
			salary = sy;
		}

		double AnnualIncome() const
		{
			return 12 * salary + 20000;
		}
	private:
		double salary;
	};

	class Dealer : public TaxPayer
	{
	public:
		Dealer(long pn, double ss) : TaxPayer(pn)
		{
			sales = ss;
		}

		double AnnualIncome() const
		{
			return 0.2 * sales;
		}
	private:
		double sales;
	};

	class SalesPerson : public Employee, public Dealer
	{
	public:
		SalesPerson(long pn, double sy, double ss) : Employee(pn, sy),  Dealer(pn, ss)
		{
		}

		double AnnualIncome() const
		{
			return Employee::AnnualIncome() - 20000 + Dealer::AnnualIncome() / 4;
		}
	};
}


#endif

