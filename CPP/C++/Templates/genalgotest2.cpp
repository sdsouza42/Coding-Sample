#include "printing.h"
#include <iostream>

using namespace Generic;
using namespace std;

bool IsOdd(long n)
{
	return (n % 2) == 1;
}


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
	long squares[] = {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};

	cout << "All squares: ";	
	PrintAll(squares, squares + 10); //array identifier is a random-access iterator(pointer)
					 //to its first element and array + size is a iterator 
					 //to its element after the last element

	cout << "Odd squares: ";	
	PrintIf(squares, squares + 10, IsOdd);

	cout << "Big squares: ";	
	PrintIf(squares, squares + 10, GreaterThan(50));
}

