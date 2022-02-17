#include "worker.h"
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <pthread.h>

long result = 0;

pthread_mutex_t monitor = PTHREAD_MUTEX_INITIALIZER;

void HandleJob(int id)
{
	long value;

	printf("Thread <%x> has accepted job:%d\n", pthread_self(), id);

	pthread_mutex_lock(&monitor);
	value = result;
	DoWork(id);
	result = value + id;
	pthread_mutex_unlock(&monitor);

	printf("Thread <%x> has finished job:%d\n", pthread_self(), id);
}

void* ChildStart(void* arg)
{
	int* p = arg;
	HandleJob(*p);
}

int main(void)
{
	register int i;
	int args[] = {1, 2, 3, 4, 5};
	pthread_t child[5];

	for(i = 0; i < 5; ++i)
	{
		pthread_create(&child[i], NULL, ChildStart, &args[i]);
	}

	for(i = 0; i < 5; ++i)
		pthread_join(child[i], NULL);

	printf("Result = %ld\n", result);
}

