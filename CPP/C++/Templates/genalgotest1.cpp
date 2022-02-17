#include "simplelist.h"
#include "printing.h"
#include <iostream>

using namespace Generic;
using namespace std;

bool IsOdd(long n)
{
	return (n % 2) == 1;
}


//functor - an object whose class has overloaded () operator
class GreaterThan
{
public:
	GreaterThan(long l)
	{
		limit = l;
	}

	bool operator()(long value) const
	{
		return value > limit;
	}
private:
	long limit;
};

int main(void)
{
	SimpleList<long> squares;
	squares.AddElement(1);
	squares.AddElement(4);
	squares.AddElement(9);
	squares.AddElement(16);
	squares.AddElement(25);
	squares.AddElement(36);
	squares.AddElement(49);
	squares.AddElement(64);
	squares.AddElement(81);
	squares.AddElement(100);

	cout << "All squares: ";	
	PrintAll(squares.Begin(), squares.End());

	cout << "Odd squares: ";	
	PrintIf(squares.Begin(), squares.End(), IsOdd);

	cout << "Big squares: ";	
	PrintIf(squares.Begin(), squares.End(), GreaterThan(50));

}

