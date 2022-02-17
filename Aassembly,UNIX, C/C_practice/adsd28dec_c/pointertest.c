#include <stdio.h>

int main()
{
   int num1, num2;
   int * p1;
   int * p2;

   num1 = 10;
   num2 = 20;

   p1 = &num1;
   p2 = &num2;

   printf("Value of Num1/Num2 is %d/%d\n",num1,num2);
   printf("Value of Num1/Num2 through pointers is %d/%d\n", *p1, *p2);

   *p1 = *p1 + 20;
   *p2 = *p2 + 30;
   printf("Value of Num1/Num2 through pointers is %d/%d\n", *p1, *p2);

   p1 = p1 + 10;
   printf("Value pointed by p1 : %d\n",*p1);

   return 0;

}
