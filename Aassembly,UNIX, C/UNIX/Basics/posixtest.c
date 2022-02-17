#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

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
		usleep(5000000);

		puts(argv[i]);
	}
}

