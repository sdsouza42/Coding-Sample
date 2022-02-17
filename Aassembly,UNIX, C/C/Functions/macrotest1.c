#include "mymacro.h"
#include <stdio.h>

int main(void)
{
	double n, s, q;

	printf("Enter a real number: ");
	scanf("%lf", &n);

	s = SQUARE(n);
	q = CUBE(n);

	printf("Square = %lf and Cube is %lf\n", s, q);
}

