#include <stdio.h>

int num1;

int main()
{
   int num2;
   num2 = 20;

   int * p = NULL;

   printf("Value in num1 is  %d\n", num1);
  
  // printf("Value pointed by p is %d\n", *p);
   printf("Address of p is %p\n", p);


   return 0;

}
