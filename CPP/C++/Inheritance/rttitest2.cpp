#include "payroll2.h"
#include <iostream>

using namespace Payroll;
using namespace std;

class SalesAgent : public SalesPerson
{
public:
	SalesAgent(double s) : SalesPerson(0, 0, s)
	{
	}

	double GetNetIncome() const
	{
		return 0.15 * GetSales();
	}
};

double GetTotalSales(Employee* group[], int count)
{
	double total = 0;

	for(int i = 0; i < count; ++i)
	{
		SalesPerson* sp = dynamic_cast<SalesPerson*>(group[i]); //explicit downcasting with RTTI
		if(sp)
			total += sp->GetSales();
	}

	return total;
}

int main(void)
{
	Employee* dept[5]; 
	dept[0] = new Employee(186, 52);
	dept[1] = new Employee(175, 95);
	dept[2] = new SalesPerson(190, 40, 65000); 
	dept[3] = new Employee(200, 225);
	dept[4] = new SalesAgent(35000);

	cout << "Total sales = "
	     << GetTotalSales(dept, 5)
	     << endl;

	for(int i = 0; i < 5; ++i)
		delete dept[i];

}

