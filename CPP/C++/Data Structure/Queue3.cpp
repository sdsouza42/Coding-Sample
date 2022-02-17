#include<stdio.h>
#include<conio.h>
#include<process.h>
#include<iostream>

using namespace std;

class Node
{
	private:
	   int data;
	   Node* next;
	   
	public:
	   //Parameterized Constructor
	   Node(int val)//10
	   {
	   	  next = NULL;
	   	  data = val;//10
	   }
	   
	   int GetData()
	   {
	   	  return data;
	   }
	   
	   void SetNext(Node* ptr)
	   {
	   	  next = ptr;
	   }
	   
	   Node* GetNext()
	   {
	   	  return next;
	   }
};

class Queue
{
	private:
	   Node* front, *rear;
	  
	public:
	   //Default Constructor
	   Queue()
	   {
	   	  front = rear = NULL;
	   }
	   
	   void Insert()
	   {
	   	  Node* newNode = NULL;
	   	  int val;
	   	  
	   	  cout<<"\nEnter any value : ";
	   	  cin>>val;//10
	   	  
	   	  newNode = new Node(val);//10
	   	  
	   	  if(front == NULL)
	   	     front = rear = newNode;
	   	  else
	   	  {
	   	  	 rear->SetNext(newNode);
	   	  	 rear = newNode;
	   	  }   
	   }
	   
	   void Delete()
	   {
	   	  Node* temp = NULL;
	   	  
	   	  if(front == NULL)
	   	     cout<<"\nQueue is Empty";
	   	  else
		  {
		  	 temp = front;
		  	 front = temp->GetNext();
		  	 
		  	 cout<<"\n"<<temp->GetData()<<" is deleted";
		  	 delete temp;
		  }
	   }
	   
	   void DisplayAllNodes()
	   {
	   	  Node* temp = NULL;
	   	  
	   	  if(front == NULL)
	   	     cout<<"\nQueue is Empty";
	   	  else
	   	  {
	   	  	 for(temp = front; temp != NULL; temp = temp->GetNext())
	   	  	    cout<<"\nData : "<<temp->GetData();
	   	  }
	   }
};

void Menu()
{
   printf("\n1. Insert Node : ");
   printf("\n2. Delete Node : ");
   printf("\n3. Display All Nodes : ");
   printf("\n4. Exit : ");
   printf("\nEnter your choice (1/2/3/4) : ");
}

int main()
{
	Queue que;
	int choice;
	
	do
	{
		system("cls");
		Menu();
		scanf("%d",&choice);
		
		switch(choice)
		{
			case 1 : que.Insert();
			         break;
			         
			case 2 : que.Delete();
			         break;
			         
			case 3 : que.DisplayAllNodes();
			         break;
			    
			case 4 : return 1;
			
			default: printf("\nWrong choice. Try Again!!!");
		}
		getch();
	}while(1);
	
	getch();
	return 1;
}
