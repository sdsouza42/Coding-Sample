#include <stdio.h>
#include <stdlib.h>

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
		long t[] = {5, 0};

		__asm__("int $128" :: "a"(162), "b"(t));

		puts(argv[i]);
	}
}

