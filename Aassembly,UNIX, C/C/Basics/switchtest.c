#include <stdio.h>

int main(void)
{
	short stay;
	int room;
	float rate;
	double payment;

	printf("Number of days: ");
	scanf("%hd", &stay);
	puts("1.Economy\n2.Business\n3.Executive\n4.Deluxe");
	printf("Room type (1-4): ");
	scanf("%d", &room);

	switch(room)
	{
	case 1:
		rate = 975;
		break;
	case 2:
		rate = 1650;
		break;
	case 3:
		rate = 2325;
		break;
	default:
		rate = 4250;
	}

	payment = 1.12 * stay * rate;

	printf("Total payment: %.2lf\n", payment);
}

