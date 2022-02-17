#include<stdio.h>
#include<conio.h>
#include<malloc.h>

typedef struct
{
	int rollNo;
	char name[15];
}Student;

int main()
{
	Student* ptr = NULL;
	
	ptr = (Student*)malloc(sizeof(Student));
	
	printf("\nEnter roll no : ");
	scanf("%d",&ptr->rollNo);
	
	printf("\nEnter name : ");
	//fflush(stdin);
	scanf("%s",&ptr->name);
	//gets(ptr->name);
	
	printf("\nRoll No : %d, Name : %s",ptr->rollNo, ptr->name);
	
	free(ptr);
	
	getch();
	return 1;
}




