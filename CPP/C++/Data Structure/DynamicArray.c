#include<stdio.h>
#include<conio.h>
#include<malloc.h>

int main()
{
	int** ptrptr = NULL;
	int i,j;
	
	ptrptr = (int**)malloc(sizeof(int*)*3);
	for(i = 0; i < 3; i++)
	   ptrptr[i] = (int*)malloc(sizeof(int)*3);
	   
	printf("\nEnter any 9 values : ");
	for(i = 0; i < 3; i++)
	{
		for(j = 0; j < 3; j++)
		{
			scanf("%d",&ptrptr[i][j]);
		}
	}
	
	for(i = 0; i < 3; i++)
	{
		for(j = 0; j < 3; j++)
		{
			printf("%d\t",ptrptr[i][j]);
		}
		printf("\n");
	}
	
	for(i = 0; i < 3; i++)
	   free(ptrptr[i]);
	   
	free(ptrptr);
	
	getch();
	return 1;
}




