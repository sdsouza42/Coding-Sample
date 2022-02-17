#include <iostream>

using namespace std;

//////////////////////////////////////////////////////

class Interval
{
public: 
	//Parameterized constructor which can be used as 
	//a default(no-argument) constructor
	//and a conversion(one-argument) constructor
	Interval(long s=0, long m=0)
	{
		time = 60 * m + s; //initialization of non-static member-variable
		++count;
	}

	void SetTime(long value) 
	{
		time = value;
	}

	long GetTime()
	{
		return time;
	}

	//non-static member-function (instance method)
	//must be called on object (using member-selection operator)
	//receives this argument (which points to object on which the function is called)
	//and as such it can access all members
	void Print()
	{
		if((time % 60) < 10)
			cout << (time / 60) << ":0" << (time % 60) << endl;
		else
			cout << (time / 60) << ":" << (time % 60) << endl;
	}

	//static member-function (class method)
	//can be called on class (using scope-resolution operator)
	//does not receive this argument 
	//and as such it cannot access non-static members
	static int Count()
	{
		return count;
	}

	//destructor - called just before object is destroyed
	~Interval()
	{
		count--;
	}

private: 
	long time; //non-static member-variable (instance field): each object will store its own value
	static int count; //static member-variable (class field): all objects will share the same value
};

int Interval::count = 0; //initialization of static-member variable of a class


////////////////////////////////////////////////////////


void Run(void)
{
	cout << "Creating Jeff's Interval" << endl;
	Interval jeff(70, 3); 
	cout << "Jeff's Interval = ";
	jeff.Print();
	cout << "Destroying Jeff's Interval" << endl; 
	//stack (unwind) sementics - local object is destroyed when it goes out of scope
}

int main(void)
{
	cout << "Creating Jack's Interval" << endl;
	Interval jack; //jack(0, 0)
	jack.SetTime(125); 
	cout << "Jack's Interval = ";
	jack.Print(); //calling non-static member function with this pointing to jack

	Run();

	cout << "Creating John's Interval" << endl;
	Interval john = 200; //john(200, 0)
	cout << "John's Interval = ";
	john.Print(); //calling non-static member function with this pointing to john

	cout << "Number of Intervals = " 
	     << Interval::Count() //calling static member function
	     << endl;
	
	cout << "Destroying John's Interval" << endl;
	cout << "Destroying Jack's Interval" << endl;
}

