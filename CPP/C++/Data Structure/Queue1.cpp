#include<stdio.h>
#include<conio.h>
#include<process.h>

typedef struct Node
{
	int data;
	struct Queue* next;
}NODE;

void Insert(NODE** fr, NODE** rr)
{
	NODE* newNode = NULL;
	
	
}

void Delete()
{
	
}

void DisplayAllNodes()
{
	
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
			         
			case 3 : DisplayAllNodes(&front);
			        break;
			    
			case 4 : return 1;
			
			default: printf("\nWrong choice. Try Again!!!");
		}
		getch();
	}while(1);
	
	getch();
	return 1;
}
