#include<stdio.h>
#include<conio.h>
#include<process.h>
#include<malloc.h>
#define MAX 5

void Insert(int queue[MAX],int* rr)
{
	int val;
	
	printf("\nEnter any value : ");
	scanf("%d",&val);
	
	if(*rr < MAX - 1)
		queue[++(*rr)] = val;
	else
	   printf("\nQueue is full");	   
}

void Delete(int queue[MAX],int* fr, int* rr)
{
	if(*fr < *rr)	
		printf("\n%d is deleted",queue[++(*fr)]);
	else
	    printf("\nQueue is Empty");
}

void DisplayAllNodes(int queue[MAX],int* fr, int* rr)
{
	int temp;
	
	if(*fr == *rr)
	   printf("\nQueue is empty");
	else
	{
		for(temp = *fr + 1; temp <= *rr; temp++)
		   printf("\nData : %d",queue[temp]);
	}
}

void Menu()
{
   printf("\n1. Insert Node : ");
   printf("\n2. Delete Node : ");
   printf("\n3. Display All Nodes : ");
   printf("\n4. Exit : ");
   printf("\nEnter your choice (1/2/3/4) : ");
}

int main()
{
	int queue[MAX];
	int choice,front = -1, rear = -1;
	
	do
	{
		system("cls");
		Menu();
		scanf("%d",&choice);
		
		switch(choice)
		{
			case 1 : Insert(queue,&rear);
			         break;
			         
			case 2 : Delete(queue,&front,&rear);
			         break;
			         
			case 3 : DisplayAllNodes(queue,&front,&rear);
			         break;
			    
			case 4 : return 1;
			
			default: printf("\nWrong choice. Try Again!!!");
		}
		getch();
	}while(1);
	
	getch();
	return 1;
}
