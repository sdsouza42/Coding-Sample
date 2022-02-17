#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <fcntl.h>
#include <sys/stat.h>

#define FIFONAME "/tmp/testfifo"
#define BUFSZ 80

int RunWriter(const char* text)
{
	int fd;
	char buffer[BUFSZ];

	fd = open(FIFONAME, O_WRONLY);
	if(fd == -1)
		return puts("ERROR: Cannot write to FIFO");

	strncpy(buffer, text, BUFSZ);
	write(fd, buffer, BUFSZ);

	close(fd);
}

int RunReader(void)
{
	int fd;
	char buffer[BUFSZ];

	fd = open(FIFONAME, O_RDONLY);
	if(fd == -1)
		return puts("ERROR: Cannot read from FIFO");

	read(fd, buffer, BUFSZ);
	printf("Received text: %s\n", buffer);

	close(fd);
}

int main(int argc, char* argv[])
{
	mkfifo(FIFONAME, 0644);

	if(argc > 1)
		RunWriter(argv[1]);
	else
		RunReader();
}

