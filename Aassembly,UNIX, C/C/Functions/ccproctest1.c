#include <stdio.h>

extern long GCD(long, long);

int main(void)
{
	long first, second, result;

	printf("Enter two positive integers: ");
	scanf("%ld%ld", &first, &second);

	result = GCD(first, second);

	printf("G.C.D = %ld\n", result);
}

