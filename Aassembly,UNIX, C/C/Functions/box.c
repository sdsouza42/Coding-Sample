#include "box.h"

long BoxGetArea(long l, long b, long h)
{
	return 2 * (l * b + b * h + h * l);
}

long BoxGetVolume(long l, long b, long h)
{
	return l * b * h;
}
