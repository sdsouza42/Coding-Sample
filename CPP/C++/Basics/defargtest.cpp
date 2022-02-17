#include <iostream>
#include <cmath>

using namespace std;

//Function that uses default argument for making parameter optional
//1. Optional parameters can only appear at the end of parameter list
//2. Default value of optional parameter must be a constant
double Income(double investment, short duration, float rate=7.5)
{
	double amount = investment * pow(1 + rate / 100, duration);

	return amount - investment;
}

int main(void)
{
	double p;
	short n;

	cout << "Enter investment and duration: ";
	cin >> p >> n;

	cout << "Income in Silver scheme: "
	     << Income(p, n) //Income(p, n, 7.5)
	     << endl;
	cout << "Income in Gold scheme: "
	     << Income(p, n, 8.5)
	     << endl;
}

