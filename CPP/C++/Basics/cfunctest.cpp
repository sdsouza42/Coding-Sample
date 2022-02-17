#include <iostream>

using namespace std;

extern "C"  int CountPrimes(long, long);

int main(void)
{
	long low, high;

	cout << "Enter low and high: ";
	cin >> low >> high;

	cout << "Number of primes: "
	     << CountPrimes(low, high)
	     << endl;
}

