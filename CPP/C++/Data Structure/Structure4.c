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
	int i;
	
	ptr = (Student*)malloc(sizeof(Student)*2);
	
	for(i=0; i < 2; i++)
	{
		printf("\nEnter roll no : ");
	    //scanf("%d",ptr[i].rollNo);
	    scanf("%d",&(*(ptr+i)).rollNo);
	    
	    printf("\nEnter name : ");
	    scanf("%s",ptr[i].name);
	}
	
	for(i=0; i < 2; i++)
       printf("\nRoll No : %d, Name : %s",ptr[i].rollNo,ptr[i].name);
	
	free(ptr);
		
	getch();
	return 1;
}




