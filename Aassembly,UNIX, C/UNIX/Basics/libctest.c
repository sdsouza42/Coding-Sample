#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void End(void)
{
	puts("Goodbye User.");
}

int main(int argc, char* argv[])
{
	register int i;

	puts("Welcome User.");
	atexit(End);

	for(i = 1; i < argc; ++i)
	{
		clock_t t = clock() + 5 * CLOCKS_PER_SEC;

		while(clock() < t);

		puts(argv[i]);
	}
}

