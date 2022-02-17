#include <stdio.h>

extern long GCDN(long, long, ...); //variadic function (with variable number of parameters)

int main(void)
{
	long first, second, third, result;

	printf("Enter three positive integers: ");
	scanf("%ld%ld%ld", &first, &second, &third);

	result = GCDN(first, second, third, 0);

	printf("G.C.D = %ld\n", result);
}

