#include<stdio.h>
#include<conio.h>
#include<malloc.h>

int main()
{
	int* ptr = NULL;
	
	//ptr = (int*)malloc(sizeof(int));
	ptr = (int*)calloc(sizeof(int),1);
	
	printf("\nEnter any value : ");
	scanf("%d",ptr);
	
	printf("\nScanned value is : %d",*ptr);
	
	printf("\nAddress of Variable : %u",ptr);
	printf("\nAddress of Pointer : %u",&ptr);
	
	free(ptr);
	
	getch();
	return 1;
}
