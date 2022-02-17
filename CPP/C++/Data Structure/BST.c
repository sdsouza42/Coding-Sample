#include<stdio.h>
#include<conio.h>
#include<process.h>
#include<malloc.h>

typedef struct Node
{
	int data;
	struct Node* left, *right;
}NODE;

void Insert(NODE** ptr)
{
	NODE* newNode = NULL, *temp = NULL;
	
	newNode = (NODE*)malloc(sizeof(NODE));
	newNode->left = newNode->right = NULL;
	
	printf("\nEnter any value : ");
	scanf("%d",&newNode->data);
	
	if(*ptr == NULL)
	   *ptr = newNode;
	else
	{
		temp = *ptr;
		while(1)
		{
			//Check whether the current value is lesser than the parent node's value
			//then move to the left
			if(newNode->data < temp->data)
			{
				if(temp->left == NULL)
				{				
				   temp->left = newNode;
				   break;
			    }
				else				
					temp = temp->left;				
			}
			else
			{
				if(temp->right == NULL)
			    {
			    	temp->right = newNode;
			    	break;
			    }
			    else
			        temp = temp->right;
			}
		}
	}
}

void PreOrder(NODE* ptr)
{
	if(ptr != NULL)
	{	
	   PreOrder(ptr->left);
	   PreOrder(ptr->right);
	   printf("\nData : %d",ptr->data);
    }
}

void PreOrderLoop(NODE* ptr)
{
	NODE* l = NULL, *r = NULL;
	
	if(ptr == NULL)
	   printf("\nBST is empty");
	else
	{
		while(1)
		{
			l = r = ptr;
			
			while(l != NULL)
			{
				r = l;
				l = l->left;
			}
			
			while(r != NULL)
			{				
				r = r->right;
			}
			
			printf("\nData : %d",ptr->data);
		}
	}
}

void InOrder(NODE* ptr)
{
	if(ptr != NULL)
	{	
	   InOrder(ptr->left);	   
	   printf("\nData : %d",ptr->data);
	   InOrder(ptr->right);
    }
}

void PostOrder(NODE* ptr)
{
	if(ptr != NULL)
	{
	   printf("\nData : %d",ptr->data);	
	   PostOrder(ptr->left);	   
	   PostOrder(ptr->right);
    }
}

void Traversal(NODE** ptr)
{
	int choice;
	
	printf("\n1. Pre-Order Traversal : ");
	printf("\n2. In-Order Traversal : ");
	printf("\n3. Post-Order Traversal : ");
	printf("\nEnter your choice (1/2/3) : ");
	scanf("%d",&choice);
	
	switch(choice)
	{
		case 1 : PreOrder(*ptr);
		         break; 
		         
		case 2 : InOrder(*ptr);
		         break;
		         
		case 3 : PostOrder(*ptr);
		         break;
		         
	    default: printf("\nWrong choice.");
	}
}

void Menu()
{
   printf("\n1. Insert Node : ");   
   printf("\n2. Traversal : ");
   printf("\n3. Exit : ");
   printf("\nEnter your choice (1/2/3) : ");
}

int main()
{
	NODE* root = NULL;
	int choice;
	
	do
	{
		system("cls");
		Menu();
		scanf("%d",&choice);
		
		switch(choice)
		{
			case 1 : Insert(&root);
			         break;
			         
			case 2 : Traversal(&root);
			         break;			         
			    
			case 3 : return 1;
			
			default: printf("\nWrong choice. Try Again!!!");
		}
		getch();
	}while(1);
	
	getch();
	return 1;
}
