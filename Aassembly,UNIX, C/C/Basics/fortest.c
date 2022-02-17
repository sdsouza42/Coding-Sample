#include <stdio.h>

int main(void)
{
	long limit, sum = 0;
	register long i;

	printf("Enter a postive integer: ");
	scanf("%ld", &limit);

	for(i = 0; i <= limit; ++i)
	{
		sum += i;
	}

	printf("Sum = %ld\n", sum);
}

