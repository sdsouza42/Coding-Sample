#include "worker.h"
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <pthread.h>

void HandleJob(int id)
{
	printf("Thread <%x> has accepted job:%d\n", pthread_self(), id);
	DoWork(id);
	printf("Thread <%x> has finished job:%d\n", pthread_self(), id);
}

void* ChildStart(void* arg)
{
	HandleJob(6);
}

int main(void)
{
	pthread_t child;

	pthread_create(&child, NULL, ChildStart, NULL);

	HandleJob(5);

	pthread_join(child, NULL); // the caller(main) thread  waits for child to exit
}

