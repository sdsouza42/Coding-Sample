#include<stdio.h>
#include<conio.h>
#include<process.h>
#include<malloc.h>

typedef struct Node
{
	int data;
	struct Node *next;
}NODE;

void Insert(NODE** rr)
{
	NODE* newNode = NULL;
	
	newNode = (NODE*)calloc(sizeof(NODE),1);
	newNode->next = NULL;
	
	printf("\nEnter any value : ");
	scanf("%d",&newNode->data);
	
	if(*rr == NULL)
	{
		*rr = newNode;
		(*rr)->next = newNode;
	}
	else
	{
		newNode->next = (*rr)->next;
	    (*rr)->next = newNode;
	    *rr = newNode;	    
	}
}

void Delete(NODE** rr)
{
	NODE* temp = NULL;
	
	if(*rr == NULL)
	   printf("\nQueue is empty");
	else
	{
		temp = (*rr)->next;
		if(*rr == temp)
		   *rr = NULL;
		else
		   (*rr)->next = temp->next;
		
		printf("\n%d is deleted",temp->data);
		free(temp);
	}
}

void DisplayAllNodes(NODE** rr)
{
	NODE* temp = NULL;
	
	if(*rr == NULL)
	   printf("\nQueue is empty");
	else
	{		
		temp = (*rr)->next;//front
		do
		{
			printf("\nData : %d",temp->data);
			temp = temp->next;			
		}while(temp != (*rr)->next);
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
	NODE* rear = NULL;
	int choice;
	
	do
	{
		system("cls");
		Menu();
		scanf("%d",&choice);
		
		switch(choice)
		{
			case 1 : Insert(&rear);
			         break;
			         
			case 2 : Delete(&rear);
			         break;
			         
			case 3 : DisplayAllNodes(&rear);
			         break;
			    
			case 4 : return 1;
			
			default: printf("\nWrong choice. Try Again!!!");
		}
		getch();
	}while(1);
	
	getch();
	return 1;
}
