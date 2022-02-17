#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <fcntl.h>
#include <sys/mman.h>

#define SHMNAME "testshm"
#define BUFSZ 4096

int RunWriter(const char* text)
{
	int fd;
	char* buffer;

	fd = shm_open(SHMNAME, O_RDWR | O_CREAT | O_EXCL, 0644);
	if(fd == -1)
		return puts("ERROR: Cannot create shared-memory block");
	ftruncate(fd, BUFSZ);

	buffer = mmap(NULL, BUFSZ, PROT_READ | PROT_WRITE, MAP_FILE | MAP_SHARED, fd, 0);
	strncpy(buffer, text, BUFSZ);
	puts("Text shared, enter any key to exit...");
	getchar();
	munmap(buffer, BUFSZ);

	close(fd);
	shm_unlink(SHMNAME);
}

int RunReader(void)
{
	int fd;
	char* buffer;

	fd = shm_open(SHMNAME, O_RDONLY, 0);
	if(fd == -1)
		return puts("ERROR: Cannot access shared-memory block");
	
	buffer = mmap(NULL, BUFSZ, PROT_READ, MAP_FILE | MAP_SHARED, fd, 0);
	printf("Shared text: %s\n", buffer);
	munmap(buffer, BUFSZ);

	close(fd);
}

int main(int argc, char* argv[])
{
	if(argc > 1)
		RunWriter(argv[1]);
	else
		RunReader();
}

