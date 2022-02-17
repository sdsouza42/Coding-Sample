#include "box.h"

/*
void BoxSetDimensions(Box box, long l, long b, long h)
{
	box[0] = l;
	box[1] = b;
	box[2] = h;
}

long BoxGetArea(Box box)
{
	long l = box[0], b = box[1], h = box[2];

	return 2 * (l * b + b * h + h * l);
}

long BoxGetVolume(Box box)
{
	long l = box[0], b = box[1], h = box[2];

	return l * b * h;
}
*/

void BoxSetDimensions(Box box, long l, long b, long h)
{
	box[0] = l;
	box[1] = b;
	box[2] = h;
	box[3] = 0;
}

void BoxSetThickness(Box box, long t)
{
	box[3] = t;
}

long BoxGetArea(Box box)
{
	long l = box[0], b = box[1], h = box[2];

	return 2 * (l * b + b * h + h * l);
}

long BoxGetVolume(Box box)
{
	long t = box[3];
	long l = box[0] - 2 * t, b = box[1] - 2 * t, h = box[2] - 2 * t;

	return l * b * h;
}

