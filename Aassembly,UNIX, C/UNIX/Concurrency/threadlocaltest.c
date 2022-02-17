#include "worker.h"
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <pthread.h>

/*
char* msg;

void WriteMessage(char* text)
{
	msg = text;
}

char* ReadMessage(void)
{
	return msg;
}
*/

pthread_key_t msgkey;

void WriteMessage(char* text)
{
	pthread_setspecific(msgkey, text);
}

char* ReadMessage(void)
{
	return pthread_getspecific(msgkey);
}

void PrintMessage(int copies)
{
	register int i;

	for(i = 1; i <= copies; ++i)
	{
		printf("%s:%d from thread <%x>\n", ReadMessage(), i, pthread_self());
		DoWork(i);
	}
}

void* ChildStart(void* arg)
{
	WriteMessage("Hello");
	PrintMessage(5);
}

int main(void)
{
	pthread_t child;

	pthread_key_create(&msgkey, NULL);
	pthread_create(&child, NULL, ChildStart, NULL);

	WriteMessage("Welcome");
	PrintMessage(5);

	pthread_join(child, NULL);
	pthread_key_delete(msgkey);
}

