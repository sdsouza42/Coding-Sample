#include<stdio.h>
#include<conio.h>
#include<malloc.h>
#include<process.h>
#define MAX 5

void Push(int stk[MAX],int* ptr)
{	
	if(*ptr < MAX - 1)
	{
		int top = ++(*ptr);
		
		printf("\nEnter any value : ");
		scanf("%d",&stk[top]);
		//scanf("%d",&stk[++(*ptr)]);
	}
	else
	   printf("\nStack is overflow");
}

void Pop(int stk[MAX],int* ptr)
{	
	if(*ptr != -1)	
		printf("\n%d is deleted",stk[(*ptr)--]);
	else
	    printf("\nStack is Empty");
}

void Peep(int stk[MAX],int* ptr)
{
	if(*ptr != -1)	
		printf("\nData : %d ",stk[*ptr]);
	else
	    printf("\nStack is Empty");
}

void DisplayAllNodes(int stk[MAX],int* ptr)
{
	int i = 0;
	
	if(*ptr == -1)
	   printf("\nStack is Empty");
	else
	{
		for(i = *ptr; i >= 0; i--)
		   printf("\nData : %d",stk[i]);
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
	int choice;
	int stk[MAX];
	int top = -1;//Equivalent to NULL for static implementation
	
	do
	{
		system("cls");
		Menu();
		scanf("%d",&choice);
		
		switch(choice)
		{
			case 1 : Push(stk,&top);
			         break;
			         
			case 2 : Pop(stk,&top);
				     break;
				     
			case 3 : Peep(stk,&top);
			         break;
			        
			case 4 : DisplayAllNodes(stk,&top);
			         break;
			         
			case 5 : return 1;
			
			default : printf("\nWrong choice. Try again!!!");
		}
		getch();
	}while(1);
}


