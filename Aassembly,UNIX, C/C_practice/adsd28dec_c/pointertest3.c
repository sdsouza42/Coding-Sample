#include <stdio.h>
#include <malloc.h>

int main()
{
   /* //example of dangling pointer
   int * num1;

   num1 = malloc(4);
   *num1 = 100;
   
   int * p = NULL;

   printf("Value at num1 is  %d\n", *num1);//values at num1
  
   printf("Address of num1 %p\n", num1); //address of num1
   p = num1; //both p and num1 points to same memory
   printf("Address of p %p\n", p);
   free(p);
   
   printf("Value pointed by num1 %d\n", *num1); //num1 is dangling 

   printf("Address of num1 %p\n", num1);
   */

   int * num1 = malloc(4);
   *num1 = 100;
   int * num2 = malloc(4);
   *num2 = 200;
   int * p = NULL;

   p = num2;
   num1 = num2;

   free(p);

   //Deallocate memory allocated for first value // Store address of num1 in some temp ptr
   
   return 0;

}
