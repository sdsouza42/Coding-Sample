#include "payroll2.h"
#include <iostream>
#include <typeinfo>

using namespace Payroll;
using namespace std;

double GetTotalSales(Employee* group[], int count)
{
	double total = 0;

	for(int i = 0; i < count; ++i)
	{
		if(typeid(*group[i]) == typeid(SalesPerson))
		{
			SalesPerson* sp = static_cast<SalesPerson*>(group[i]); //explicit downcasting
			total += sp->GetSales();
		}
	}

	return total;
}

int main(void)
{
	Employee* dept[5]; 
	dept[0] = new Employee(186, 52);
	dept[1] = new Employee(175, 95);
	dept[2] = new SalesPerson(190, 40, 65000); //implicit upcating
	dept[3] = new Employee(200, 225);
	dept[4] = new SalesPerson(165, 55, 35000);

	cout << "Total sales = "
	     << GetTotalSales(dept, 5)
	     << endl;

	for(int i = 0; i < 5; ++i)
		delete dept[i];

}

