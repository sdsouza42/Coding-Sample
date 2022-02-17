#include<stdio.h>
#include<conio.h>
#include<iostream>

using namespace std;

class Node
{
	private:
		int data;
		Node* next;
	
	public:
		//parameterized constructor
		Node(int val)
		{
			next = NULL;
			data = val;
		}
		
		int& GetData()
		{
			return data;
		}
		
		void SetNext(Node*& ptr)//5008
		{
			next = ptr;
		}
		
		Node*& GetNext()
		{
			return next;
		}
};

class Stack
{
	private:
	   Node* top;
	   
	public:
		Stack()
		{
			top = NULL;
		}
		
		void Push()
		{
		   Node* temp = NULL;
		   int val;
		   
		   cout<<"\nEnter any value : ";
		   cin>>val;
		   	
		   temp = new Node(val);
		   
		   if(top == NULL)
		      top = temp;
		   else
		   {
		   	  //temp->next = top;
		   	  temp->SetNext(top);//5008
		   	  top = temp;
		   }
		}
		
		void Pop()
		{
			Node* temp = NULL;
			
			if(top == NULL)
			   cout<<"\nStack is Empty";
			else
			{
			   temp = top;
			   cout<<"\n"<<top->GetData()<<" is deleted";
			   top = temp->GetNext();
			   delete temp;
			}
		}
		
		void Peep()
		{	
			if(top == NULL)
			   cout<<"\nStack is Empty";
			else			
			   cout<<"\nData : "<<top->GetData();			
		}
		
		void DisplayAllNodes()
		{
			Node* temp = NULL;
			
			if(top == NULL)
			   cout<<"\nStack is Empty";
			else
			{
				for(temp = top; temp != NULL; temp = temp->GetNext())
				   cout<<"\nData : "<<temp->GetData();
			}
		}
		
		~Stack()
		{	
		    NODE* temp = NULL;
		    
			if(top != NULL)
			{
				for(;top != NULL; )
				{				   	
				   temp = top;
				   top = top->GetNext();
				   delete temp;
				}
			}
			cout<<"Top : "<<top;
		}
};

void Menu()
{
   printf("\n1. Push : ");	
   printf("\n2. Pop : ");
   printf("\n3. Peep : ");
   printf("\n4. Display All Nodes : ");
   printf("\n5. Exit : ");
   printf("\nEnter your choice (1/2/3/4/5) : ");
}

int main()
{
	int choice;
	Stack stk;
	
	do
	{
		system("cls");
		Menu();
		scanf("%d",&choice);
		
		switch(choice)
		{
			case 1 : stk.Push();
			         break;
			         
			case 2 : stk.Pop();
				     break;
				     
			case 3 : stk.Peep();
			         break;
			        
			case 4 : stk.DisplayAllNodes();
			         break;
			         
			case 5 : return 1;
			
			default : printf("\nWrong choice. Try again!!!");
		}
		
		getch();
	}while(1);
}


