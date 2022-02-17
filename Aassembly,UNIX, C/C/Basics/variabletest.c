#include <stdio.h>

long length;
long breadth = 0, perim = 10;

int main(void)
{
	long area;

	printf("Enter length and breadth: ");
	scanf("%ld%ld", &length, &breadth);

	perim = 2 * (length + breadth);
	area = length * breadth;

	printf("Perimiter = %ld and Area = %ld\n", perim, area);
}

