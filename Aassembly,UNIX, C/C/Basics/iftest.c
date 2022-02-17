#include <stdio.h>

const long array[] = {111, 222, 333, 444, 555, 666, 777, 888};

int main(void)
{
	int index;
	long value;

	printf("Index (0-7): ");
	scanf("%d", &index);

	if(index >= 0 && index <= 7)
	{
		value = array[index];
		printf("Value = %ld\n", value);
	}

	puts("Goodbye.");
}

