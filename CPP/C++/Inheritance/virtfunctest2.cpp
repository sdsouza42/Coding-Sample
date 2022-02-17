//#define _TESTING
#include "payroll2.h"
#include <iostream>

using namespace Payroll;
using namespace std;

double GetAverageIncome(Employee* group[], int count)
{
	double total = 0;

	for(int i = 0; i < count; ++i)
	{
		total += group[i]->GetNetIncome();
	}

	return total / count;
}

int main(void)
{
	Employee* dept[5]; //polymorphic array
	dept[0] = new Employee(186, 52);
	dept[1] = new Employee(175, 95);
	dept[2] = new SalesPerson(190, 40, 65000); //implicit conversion from derived to base
	dept[3] = new Employee(200, 225);
	dept[4] = new SalesPerson(165, 55, 35000);

	cout << "Average income = "
	     << GetAverageIncome(dept, 5)
	     << endl;

	for(int i = 0; i < 5; ++i)
		delete dept[i];
}


