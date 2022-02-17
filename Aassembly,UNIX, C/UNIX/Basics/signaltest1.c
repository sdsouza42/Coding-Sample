#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <signal.h>

void End(void)
{
	puts("Finalizing...");
}

long Calculate(long n)
{
	return 2520 / n;
}

void Run(void)
{
	long squares[] = {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};
	register int i;

	for(i = 1; i <= 3; ++i)
	{
		long value;

		printf("Value %d: ", i);
		scanf("%ld", &value);

		printf("Result = %ld\n", Calculate(value));
		printf("Entry  = %ld\n", squares[value]);
	}
}

void MainHandler(int signo)
{
	switch(signo)
	{
	case SIGFPE:
		puts("ERROR: Illegal arithmatic operation!");
		break;
	case SIGSEGV:
		puts("ERROR: Illegal memory access!");
		break;
	case SIGINT:
		puts("");
		break;
	}

	exit(signo);
}

int main(void)
{
	struct sigaction act = {MainHandler};

	sigaction(SIGFPE, &act, NULL);
	sigaction(SIGSEGV, &act, NULL);
	sigaction(SIGINT, &act, NULL);

	puts("Initializing...");
	atexit(End);

	Run();
}

