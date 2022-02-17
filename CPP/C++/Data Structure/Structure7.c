#include<stdio.h>
#include<conio.h>
#include<malloc.h>

struct Student
{
	int rollNo;
	char name[15];
	struct Student* next;
};

typedef struct Student STUD;

int main()
{
	STUD* ptr1 = NULL,*ptr2 = NULL, *temp = NULL;
	
	ptr1 = (STUD*)malloc(sizeof(STUD));
	ptr2 = (STUD*)malloc(sizeof(STUD));

	ptr1->next = ptr2;
	ptr2->next = NULL;

	printf("\nEnter roll no : ");
	scanf("%d",&ptr1->rollNo);
	
	printf("\nEnter name : ");
	scanf("%s",ptr1->name);
	
	printf("\nEnter roll no : ");
	scanf("%d",&ptr2->rollNo);
	
	printf("\nEnter name : ");
	scanf("%s",ptr2->name);
	
	for(temp = ptr1; temp != NULL; temp = temp->next)
	   printf("\nRoll No : %d, Name : %s",temp->rollNo, temp->name);
	
	free(ptr1);
	free(ptr2);
	
	getch();
	return 1;
}






