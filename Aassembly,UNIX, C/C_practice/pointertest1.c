#include <stdio.h>

int main()
{
   int num1, num2;
   const int * p1; //pointer points integer content that is constant ****
   int * const p2 = &num2; // constant pointer points to integer (integer is not constant)
   const int * const p3 = &num1; //constant pointer and points to integer that is constant
   num1 = 10;
   num2 = 20;

   p1 = &num1;

   printf("Value of Num1/Num2 is %d/%d\n",num1,num2);
   printf("Value of Num1/Num2 through pointers is %d/%d\n", *p1, *p2);

   //*p1 = *p1 + 20; Not allowed because p points to integer which is constant
   //p2 = &num1; //Not allowed because pointer p2 is constant pointer.
   //*p2 = *p2 + 30;


   //p3 = &num2;  Not allowed
   //*p3 = 50;

   printf("Sizeof of pointer is %d\n", sizeof(p1));

   printf("Sizeof of pointer is %d\n", sizeof(long double));

   return 0;

}
