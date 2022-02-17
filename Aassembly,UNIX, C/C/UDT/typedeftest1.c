#include "box.h"
#include <stdio.h>

int main(void)
{
	Box mybox;
	long l, b, h, area, volume;

	printf("Enter box dimensions: ");
	scanf("%ld%ld%ld", &l, &b, &h);

	BoxSetDimensions(mybox, l, b, h);
	area = BoxGetArea(mybox);
	volume = BoxGetVolume(mybox);

	printf("Area = %ld and Volume = %ld\n", area, volume);
}

