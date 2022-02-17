#include "mymacro.h"
#include <stdio.h>

int main(void)
{
	long limit;
	register long n;

	printf("Enter limit: ");
	scanf("%ld", &limit);

	for(n = 1; n <= limit; ++n)
	{
		long result;

		#ifdef _HIGH
		result = CUBE(n);
		#else
		result = SQUARE(n);
		#endif

		printf("%ld\t%ld\n", n, result);
	}
}

