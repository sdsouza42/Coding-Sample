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
	if(n < 0)
		raise(SIGUSR1);

	return 2520 / n;
}

void RunHandler(int signo)
{
	puts("ERROR: Illegal value!");
	exit(signo);
}

void Run(void)
{
	long squares[] = {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};
	register int i;

	struct sigaction act = {RunHandler};
	struct sigaction oact;

	sigaction(SIGUSR1, &act, &oact);

	for(i = 1; i <= 3; ++i)
	{
		long value;

		printf("Value %d: ", i);
		scanf("%ld", &value);

		printf("Result = %ld\n", Calculate(value));
		printf("Entry  = %ld\n", squares[value]);
	}

	sigaction(SIGUSR1, &oact, NULL);
}

int main(void)
{
	puts("Initializing...");
	atexit(End);

	Run();
}

