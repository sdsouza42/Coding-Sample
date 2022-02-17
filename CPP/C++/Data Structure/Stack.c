#include<stdio.h>
#include<conio.h>
#include<malloc.h>
#include<process.h>

struct Node
{
	int data;
	struct Node* next;
};

typedef struct Node NODE;

void Push(NODE** ptr)
{
	NODE* newNode = NULL;
	
	newNode = (NODE*)malloc(sizeof(NODE));
	newNode->next = NULL;
	
	printf("\nEnter any value : ");
	scanf("%d",&newNode->data);
	
	/*if(*ptr == NULL)
	   *ptr = newNode;
	else
	{
		newNode->next = *ptr;
		*ptr = newNode;
	}*/
	
	//Previously Commented statements is equals to the next statements
	if(*ptr != NULL)
	   newNode->next = *ptr;
	   
	*ptr = newNode;
}

void Pop(NODE** ptr)
{
	NODE* temp = NULL;
	
	if(*ptr == NULL)
	   printf("\nStack is Empty");
	else
	{
		temp = *ptr;
		*ptr = temp->next;
		
		printf("\n%d is deleted",temp->data);
		free(temp);
	}
}

void Peep(NODE** ptr)
{	
    /*
	//This is similar to write (*ptr)->data
	//ptr first needs to points to head and then data variable
	NODE* temp;
    
    temp = *ptr;
    temp->data;*/
    
	if(*ptr == NULL)
	   printf("\nStack is Empty");
	else
	   printf("Data : %d",(*ptr)->data);
}

void DisplayAllNodes(NODE** ptr)
{
	NODE* temp = NULL;
	
	if(*ptr == NULL)
	   printf("\nStack is Empty");
	else
	{
		for(temp = *ptr; temp != NULL; temp = temp->next)
		   printf("\nData : %d",temp->data);
	}
}

void Menu()
{
   printf("\n1. Push : ");	
   printf("\n2. Pop : ");
   printf("\n3. Peep : ");
   printf("\n4. Display All Nodes : ");
   printf("\n5. Exit : ");
   printf("\nEnter your choice (1/2/3/4/5) : ");
}

int main()
{
	NODE* head = NULL;
	int choice;
	
	do
	{
		system("cls");
		Menu();
		scanf("%d",&choice);
		
		switch(choice)
		{
			case 1 : Push(&head);
			         break;
			         
			case 2 : Pop(&head);
				     break;
				     
			case 3 : Peep(&head);
			         break;
			        
			case 4 : DisplayAllNodes(&head);
			         break;
			         
			case 5 : return 1;
			
			default : printf("\nWrong choice. Try again!!!");
		}
		getch();
	}while(1);
}


