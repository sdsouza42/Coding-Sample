#include <stdio.h>

int main(void)
{
	short stay;
	int room;
	float rate;
	double payment;

	printf("Number of days: ");
	scanf("%hd", &stay);
	puts("1.Economy\n2.Business");
	printf("Room type (1-2): ");
	scanf("%d", &room);

	if(room == 1)
	{
		rate = 975;
	}
	else
	{
		rate = 1650;
	}

	payment = 1.12 * stay * rate;

	printf("Total payment: %.2lf\n", payment);
}

