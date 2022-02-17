#include<stdio.h>
#include<conio.h>
#include<malloc.h>

struct DateOfBirth
{
	int dd,mm,yyyy;	
};

struct Student
{
	int rollNo;
	char name[15];
	struct DateOfBirth dob;
};

int main()
{
	struct Student* ptr = NULL;
	
	ptr = (struct Student*)malloc(sizeof(struct Student));
	
	printf("\nEnter roll no : ");
	scanf("%d",&ptr->rollNo);
	
	printf("\nEnter name : ");
	scanf("%s",ptr->name);
	
	printf("\nEnter Date of Birth (dd mm yyyy) format : ");
	scanf("%d%d%d",&ptr->dob.dd, &ptr->dob.mm,&ptr->dob.yyyy);
	
	printf("\nRoll No : %d, Name : %s, Date of birth : %d-%d-%d",ptr->rollNo, ptr->name, ptr->dob.dd, ptr->dob.mm,ptr->dob.yyyy);
	
	free(ptr);
	
	getch();
	return 1;
}



