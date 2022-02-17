#include<stdio.h>
#include<conio.h>
#include<iostream>

using namespace std;

int main()
{
	int val = 10;
	int* ptr = &val;
	int*& ptrRef = ptr;
	
	cout<<ptr<<endl;
	cout<<ptrRef<<endl;
	
	cout<<&ptr<<endl;
	cout<<&ptrRef;
	
	getch();
	return 1;
}
