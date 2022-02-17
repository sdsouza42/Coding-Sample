#include<stdio.h>
#include<conio.h>
#include<malloc.h>
#include<process.h>

struct Student
{
	int rollNo;
	char name[15];
	struct Student* next;
};

typedef struct Student STUD;

void AddStudent(STUD** ptr)
{
	STUD* temp = NULL,*temp2 = NULL;
	
	temp = (STUD*)malloc(sizeof(STUD));
	temp->next = NULL;
	
	printf("\nEnter roll no : ");
	scanf("%d",&temp->rollNo);
	
	printf("\nEnter name : ");
	scanf("%s",temp->name);
	
	if(*ptr == NULL)
	   *ptr = temp;
	else
	{
		for(temp2 = *ptr; temp2->next != NULL; temp2 = temp2->next);
		
		temp2->next = temp;
	}
}

void DisplayData(STUD** ptr)
{
	STUD* temp = NULL;
	
	if(*ptr == NULL)
	   printf("\nNo Records found");
	else
	{
		for(temp = *ptr; temp != NULL; temp = temp->next)
		   printf("\nRoll No : %d, Name : %s",temp->rollNo, temp->name);
	}
}

void Menu()
{
   printf("\n1. Add Student Record : ");	
   printf("\n2. Print All Students Record : ");
   printf("\n3. Exit : ");
   printf("\nEnter your choice (1/2/3) : ");
}

int main()
{
	STUD* root = NULL;
	int choice;
	
	do
	{
		system("cls");
		Menu();
		scanf("%d",&choice);
		
		switch(choice)
		{
			case 1 : AddStudent(&root);
			         break;
			
			case 2 : DisplayData(&root);
			         break;
			    
			case 3 : return 1;
			
			default : printf("\nWrong choice. Try again!!!");
		}
		getch();
	}while(1);
	
	getch();
	return 1;
}






