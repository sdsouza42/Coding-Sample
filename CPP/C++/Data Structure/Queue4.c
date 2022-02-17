#include<stdio.h>
#include<conio.h>
#include<process.h>
#include<malloc.h>

typedef struct Node
{
	int data;
	struct Node *prev, *next;
}NODE;

void Insert(NODE** fr, NODE** rr)
{
	NODE* newNode = NULL;
	
	newNode = (NODE*)calloc(sizeof(NODE),1);
	newNode->prev = newNode->next = NULL;
	
	printf("\nEnter any value : ");
	scanf("%d",&newNode->data);
	
	if(*fr == NULL)
	   *fr = *rr = newNode;
	else
	{
	   (*rr)->next = newNode;
	   newNode->prev = *rr;
	   *rr = newNode;
	}
}

void Delete(NODE** fr)
{
	NODE* temp = NULL;
	
	if(*fr == NULL)
	   printf("\nQueue is empty");
	else
	{
		temp = *fr;
		*fr = temp->next;
		
		if(*fr != NULL)
		  (*fr)->prev = NULL;
		
		printf("\n%d is deleted",temp->data);
		free(temp);
	}
}

void DisplayAllNodes(NODE** fr, NODE** rr)
{
	NODE* temp = NULL;
	
	if(*fr == NULL)
	   printf("\nQueue is empty");
	else
	{
		printf("\nNode values from Front to Rear\n");
		for(temp = *fr; temp != NULL; temp = temp->next)
		   printf("\nData : %d",temp->data);
		
		printf("\nNode values from Rear to Front\n");
		for(temp = *rr; temp != NULL; temp = temp->prev)
		   printf("\nData : %d",temp->data);
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
	NODE* front = NULL, *rear = NULL;
	int choice;
	
	do
	{
		system("cls");
		Menu();
		scanf("%d",&choice);
		
		switch(choice)
		{
			case 1 : Insert(&front,&rear);
			         break;
			         
			case 2 : Delete(&front);
			         break;
			         
			case 3 : DisplayAllNodes(&front,&rear);
			         break;
			    
			case 4 : return 1;
			
			default: printf("\nWrong choice. Try Again!!!");
		}
		getch();
	}while(1);
	
	getch();
	return 1;
}
