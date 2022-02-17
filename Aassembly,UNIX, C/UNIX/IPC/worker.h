#include <time.h>

int DoWork(int n)
{
	clock_t t;

	if(n <= 0)
		n = 1 + time(NULL) % 10;
	t = clock() + n * CLOCKS_PER_SEC;
	while(clock() < t);

	return n;
}

