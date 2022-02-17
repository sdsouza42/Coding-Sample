#include <iostream>
#include <string>

using namespace std;
/*
void Swap(long& first, long& second)
{
	long third = first;

	first = second;
	second = third;
}

void Swap(double& first, double& second)
{
	double third = first;

	first = second;
	second = third;
}
*/

//Swap function template with T as (replaceable) type parameter
template<typename T>
void Swap(T& first, T& second)
{
	T third = first;

	first = second;
	second = third;
}

int main(void)
{
	long lx = 123, ly = 321;
	cout << "Original long values = " << lx << ", " << ly << endl;
	Swap<long>(lx, ly); //calling templated Swap function with T=long
	cout << "Swapped long values  = " << lx << ", " << ly << endl;

	double dx = 23.4, dy = 34.5;
	cout << "Original double values = " << dx << ", " << dy << endl;
	Swap(dx, dy); //Swap<double>(dx, dy) - type deduction (T=double)
	cout << "Swapped double values  = " << dx << ", " << dy << endl;
}

