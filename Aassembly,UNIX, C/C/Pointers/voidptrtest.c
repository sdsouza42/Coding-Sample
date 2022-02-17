#include <stdio.h>

/*
void SwapLong(long* first, long* second)
{
	long third = *first;

	*first = *second;
	*second = third;
}

void SwapDouble(double* first, double* second)
{
	double third = *first;

	*first = *second;
	*second = third;
}
*/

void SwapAny(void* first, void* second, int size)
{
	char* pf = first;
	char* ps = second;
	register int i;

	for(i = 0; i < size; ++i)
	{
		char t = pf[i];

		pf[i] = ps[i];
		ps[i] = t;
	}

}

#define Swap(X, Y) SwapAny(&X, &Y, sizeof(X))

int main(void)
{
	long lx = 23, ly = 32;
	double dx = 3.45, dy = 4.56;

	printf("Original long values: %ld, %ld\n", lx, ly);
	//SwapLong(&lx, &ly);
	//SwapAny(&lx, &ly, 4);
	Swap(lx, ly);
	printf("Swapped long values : %ld, %ld\n", lx, ly);
	
	printf("Original double values: %lf, %lf\n", dx, dy);
	//SwapDouble(&dx, &dy);
	//SwapAny(&dx, &dy, 8);
	Swap(dx, dy);
	printf("Swapped double values : %lf, %lf\n", dx, dy);
}

