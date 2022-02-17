#include<stdio.h>
#include<conio.h>
#include<malloc.h>

typedef struct
{
	int rollNo;
	char* name;
}Student;

int main()
{
	Student* ptr = NULL;
	
	ptr = (Student*)malloc(sizeof(Student));
	ptr->name = (char*)malloc(sizeof(char)*15);
	
	printf("\nEnter roll no : ");
	scanf("%d",&ptr->rollNo);
	
	printf("\nEnter name : ");
	fflush(stdin);
	gets(ptr->name);
	
	printf("\nRoll No : %d, Name : %s",(*(ptr)).rollNo, ptr->name);
		
	free(ptr->name);
	free(ptr);
	
	getch();
	return 1;
}




