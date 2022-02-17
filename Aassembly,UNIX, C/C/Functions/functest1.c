#include <stdio.h>

extern int CountPrimes(long, long); //function declaration

int main(void)
{
	long l, h;
	int count;

	printf("Enter range: ");
	scanf("%ld%ld", &l, &h);

	count = CountPrimes(l, h);

	printf("Number of primes = %d\n", count);
}
