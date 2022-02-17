#include <stdio.h>
#include <malloc.h>

int main()
{
  int * marks = NULL;
  int * p;
  int no;
  int i;
  printf("Enter the no of subjects\n");
  scanf("%d", &no);

  marks = malloc(no * 4);
  p = marks;
 /* marks[1] = 10;
  marks[2] = 20;
  marks[3] = 30
 */
  for(i = 0; i < no; i++)
  {
	printf("Enter marks for subject %d \n", i + 1);
	scanf("%d", p++);
  }
  
  p = marks;
  for(i = 0; i < no; i++)
  {
	printf("Marks for subject %d is %d \n", i + 1, *(p++));
  }
  return 0;


}
