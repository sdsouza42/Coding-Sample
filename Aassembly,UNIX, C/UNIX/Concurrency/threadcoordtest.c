#include "worker.h"
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <pthread.h>

volatile long value = 0;

void Produce(void)
{
	printf("Producer thread <%x> ready...\n", pthread_self());

	value = DoWork(0);
}

void* Consume(void* arg)
{
	printf("Consumer thread <%x> ready...\n", pthread_self());

	while(value == 0)
		pthread_yield();

	printf("Processed value = %ld\n", value * value);
}

int main(void)
{
	pthread_t child;

	pthread_create(&child, NULL, Consume, NULL);

	Produce();

	pthread_join(child, NULL);
}


