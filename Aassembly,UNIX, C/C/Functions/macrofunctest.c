#include <stdio.h>

extern int CountPrimes(long, long); //function declaration

#define CountPrimesUpto(X) CountPrimes(1, X)

int main(void)
{
	long l;
	int count;

	printf("Enter limit: ");
	scanf("%ld", &l);

	count = CountPrimesUpto(l);

	printf("Number of primes = %d\n", count);
}
