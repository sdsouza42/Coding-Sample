#include <stdio.h>

int main(void)
{
	long number, digits;
	register long a, b, c;

	printf("Enter a positive integer: ");
	scanf("%ld", &number);

	a = 1;
	b = number;
	c = 0;

	do
	{
		a *= 10; // a = a * 10
		c += 1; // c = c + 1
	}
	while(a <= b);

	digits = c;

	printf("Number of digits = %ld\n", digits);
}

