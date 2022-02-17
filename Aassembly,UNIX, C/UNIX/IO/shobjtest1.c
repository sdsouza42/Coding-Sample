#include <stdio.h>
#include <string.h>

extern int ProcessBuffer(char[], int);

int main(void)
{
	char text[80];

	printf("Text to encrypt: ");
	scanf("%79[^\n]s", text);

	ProcessBuffer(text, strlen(text));

	printf("Encrypted text : %s\n", text);
}
