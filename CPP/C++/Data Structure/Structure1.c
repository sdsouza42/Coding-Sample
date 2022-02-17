#include<stdio.h>
#include<conio.h>
#include<malloc.h>

int main()
{
	int* ptr = NULL;
	int i;
	
	ptr = (int*)malloc(sizeof(int)*5);
	//ptr = (int*)calloc(sizeof(int),5);
	
	printf("\nEnter any 5 values : ");
	for(i = 0; i < 5; i++)
	    //scanf("%d",&ptr[i]);
	    scanf("%d",&(*(ptr+i)));
	
	for(i = 0; i < 5; i++)
	    printf("\n%d",*(ptr+i));
		
	free(ptr);
	
	getch();
	return 1;
}




