#ifdef _DDOD
#include "taxation1.h"
#else
#include "taxation2.h" //virtual inheritance
#endif
#include <iostream>

using namespace Taxation;
using namespace std;


int main(void)
{
	Employee jill(123456, 24000);
	Dealer jack(234567, 3000000);
	SalesPerson jeff(345678, 15000, 800000);
	cout << "Jill the Employee: "
	     << jill
	     << endl;
	cout << "Jack the Dealer: "
	     << jack
	     << endl;
	cout << "Jeff the SalesPerson: "
	     #ifdef _DDOD
	     << static_cast<Employee&>(jeff)
	     #else
	     << jeff
	     #endif
	     << endl;

	cout << "Number of TaxPayers = " << TaxPayer::Count() << endl;

	cout << &jill << "\t" << static_cast<TaxPayer*>(&jill) << endl;
}

