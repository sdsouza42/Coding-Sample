#include <stdio.h>

double list[] = {1.23, 2.34, 3.45, 4.56, 5.67, 6.78, 7.89};

int main(void)
{
	double* a = &list[3];
	double* b = a + 3;

	printf("%p -> %lf\n", a, *a);
	printf("%p -> %lf\n", b, *b);
	printf("%p[-2] == %lf\n", a, a[-2]);
}

