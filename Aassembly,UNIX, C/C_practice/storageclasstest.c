#include <stdio.h>

int x = 100; //data section

void GetA()
{
   printf("Global data value :%d \n", x);
  
}

int GetCount()
{
 static int count = 0; //static local variable

 count++;

 return count;

}


int main()
{
  int y; //stack


  printf("%d\n",y);
  GetA();
  printf("Value getcount return : %d\n",GetCount());
  printf("Value getcount return : %d\n",GetCount());
   printf("Count value :%d \n", count);
  return 0;

}

