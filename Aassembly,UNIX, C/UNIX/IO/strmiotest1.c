#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <fcntl.h>

#define BUFSZ 80

extern int ProcessBuffer(char[], int);

//char buffer[BUFSZ]; //static allocation

int main(int argc, char* argv[])
{
	int fdi, fdo, n;
	char buffer[BUFSZ]; //automatic allocation

	if(argc < 3)
		return printf("USAGE: %s source-file target-file\n", argv[0]);
	
	fdi = open(argv[1], O_RDONLY, 0);
	if(fdi == -1)
		return printf("ERROR: Cannot open %s\n", argv[1]);

	fdo = open(argv[2], O_WRONLY | O_CREAT | O_EXCL, 0640);
	if(fdo == -1)
		return printf("ERROR: Cannot create %s\n", argv[2]);

	do
	{
		n = read(fdi, buffer, BUFSZ);
		ProcessBuffer(buffer, n);
		write(fdo, buffer, n);
	}
	while(n == BUFSZ);

	close(fdo);
	close(fdi);
}
