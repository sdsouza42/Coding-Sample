#include <stdio.h>

long AddAll(long first, long last)
{
	long sum = 0;
	register long value;

	for(value = first; value <= last; ++value)
	{
		sum += value;
	}

	return sum;
}

long AddIf(long first, long last, int (*select)(long))
{
	long sum = 0;
	register long value;

	for(value = first; value <= last; ++value)
	{
		if(select(value)) //call-back
			sum += value;
	}

	return sum;
}

int IsOdd(long n)
{
	return n % 2;
}

int main(void)
{
	long limit, total;

	printf("Enter limit: ");
	scanf("%ld", &limit);

	total = AddAll(1, limit);
	printf("Sum of all integers upto %ld is %ld\n", limit, total);

	total = AddIf(1, limit, IsOdd);
	printf("Sum of odd integers upto %ld is %ld\n", limit, total);

}

