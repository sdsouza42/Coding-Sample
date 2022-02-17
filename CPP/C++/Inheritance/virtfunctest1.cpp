#include "payroll2.h"
#include <iostream>

using namespace Payroll;
using namespace std;

//polymorphic function
double GetIncomeTax(const Employee& entry)
{
	double i = entry.GetNetIncome(); //dynamic binding using vptr/v-table
					 //for an indirected virtual call

	return i > 10000 ? 0.15 * (i - 10000) : 0;
}

int main(void)
{
	Employee jack;
	jack.SetHours(186);
	jack.SetRate(52);
	cout << "Jack's Income is "
	     << jack.GetNetIncome()
	     << " and Tax is "
	     << GetIncomeTax(jack)
	     << endl;

	SalesPerson jill(186, 52, 74000);
	cout << "Jill's Income is "
	     << jill.GetNetIncome()
	     << " and Tax is "
	     << GetIncomeTax(jill)
	     << endl;
	
	return sizeof(jack);
}

