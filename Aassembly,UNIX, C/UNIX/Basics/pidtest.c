#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

int main(void)
{
	pid_t current = getpid();
	pid_t parent = getppid();

	printf("This is process <%d/%d>\n", current, parent);
}

