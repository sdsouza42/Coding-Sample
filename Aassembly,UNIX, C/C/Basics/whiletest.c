#include <stdio.h>

const long array[] = {111, 222, 333, 444, 555, 444, 333, 222, 111};

int main(void)
{
	int index = 0;
	long value;

	printf("Value: ");
	scanf("%ld", &value);

	while(index < 9)
	{
		if(array[index] == value)
			printf("Found at index %d\n", index);
		index += 1;
	}

	puts("Goodbye.");

}

