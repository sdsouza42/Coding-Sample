#include <stdio.h>

enum RoomType {Economy=1, Business, Executive, Deluxe};

double HotelGetPayment(short stay, enum RoomType room)
{
	float rate;

	switch(room)
	{
	case Economy:
		rate = 975;
		break;
	case Business:
		rate = 1250;
		break;
	case Executive:
		rate = 2500;
		break;
	default:
		rate = 3750;
	}

	return 1.12 * stay * rate;
}

int main(void)
{
	short days;

	printf("Enter number of days: ");
	scanf("%hd", &days);

	printf("Total payment for economy class room will be %.2f\n", HotelGetPayment(days, Economy));
	printf("Total payment for business class room will be %.2f\n", HotelGetPayment(days, Business));
	printf("Total payment for executive class room will be %.2f\n", HotelGetPayment(days, Executive));
	printf("Total payment for deluxe class room will be %.2f\n", HotelGetPayment(days, Deluxe));
}


