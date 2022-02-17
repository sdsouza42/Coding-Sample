#include <iostream>

using namespace std;

//////////////////////////////////////////////////////

class Interval
{
public: 
	//Default (parameterless) constructor
	Interval()
	{
		time = 0;
	}

	//Conversion (single-parameter) constructor
	Interval(long t)
	{
		time = t;
	}

	//Parameterized constructor
	Interval(long s, long m)
	{
		time = 60 * m + s;
	}

	void SetTime(long value) 
	{
		time = value;
	}

	long GetTime()
	{
		return time;
	}

	void Print()
	{
		if((time % 60) < 10)
			cout << (time / 60) << ":0" << (time % 60) << endl;
		else
			cout << (time / 60) << ":" << (time % 60) << endl;
	}

private: 
	long time;
};


////////////////////////////////////////////////////////


int main(void)
{
	Interval jack; //instantiation using default constructor
	jack.SetTime(125); 
	cout << "Jack's Interval = ";
	jack.Print();

	Interval john = 200; //instantiation using conversion constructor
	cout << "John's Interval = ";
	john.Print();
	
	Interval jeff(70, 3); //instantiation using parameterized contructor
	cout << "Jeff's Interval = ";
	jeff.Print();
}

