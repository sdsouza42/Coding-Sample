#include <iostream>
#include <cmath>

using namespace std;

double Income(double investment, short duration, float rate)
{
	double amount = investment * pow(1 + rate / 100, duration);

	return amount - investment;
}

//Overloaded function (same name but different parameters) to make parameter optional
//A C++ function's call-site always contains its name and the values of its parameters
//but return value is optional so a function is identified by its name and the types
//of its parameters but not by its return-type, hence function cannot be overloaded only 
//by its return-type
//inline modifier requests compiler to expand the function at its call-site
inline double Income(double investment, short duration)
{
	return Income(investment, duration, duration < 3 ? 7.5 : 8.0);
}

int main(void)
{
	double p;
	short n;

	cout << "Enter investment and duration: ";
	cin >> p >> n;

	cout << "Income in Silver scheme: "
	     << Income(p, n) //Income(p, n, n < 3 ? 7.5 : 8.0)
	     << endl;
	cout << "Income in Gold scheme: "
	     << Income(p, n, 8.5)
	     << endl;
}

