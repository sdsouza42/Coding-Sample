#include <iostream>

using namespace std;

//////////////////////////////////////////////////////

class Interval
{
public: 
	//cannot be used as a conversion constructor
	explicit Interval(long m=0, long s=0)
	{
		time = 60 * m + s; 
		++count;
	}

	void SetTime(long value)
	{
		time = value;
	}

	long GetTime() const //long Interval::GetTime(const Interval* this)
	{
		return time; //return this->time;
	}

	void Print() const
	{
		if((time % 60) < 10)
			cout << (time / 60) << ":0" << (time % 60) << endl;
		else
			cout << (time / 60) << ":" << (time % 60) << endl;
	}

	static int Count()
	{
		return count;
	}

	~Interval()
	{
		count--;
	}

private: 
	long time;
	static int count; 
};

int Interval::count = 0;

////////////////////////////////////////////////////////

float Speed(float distance, const Interval& duration)
{
	return 3.6 * distance / duration.GetTime(); //Interval::GetTime(&duration)
}

int main(void)
{
	cout << "Creating Jack's Interval" << endl;
	Interval jack;
	jack.SetTime(125); 
	cout << "Jack's Interval = ";
	jack.Print(); 
	cout << "Jack's Speed = " << Speed(500, jack) << endl;

	cout << "Creating John's Interval" << endl;
	Interval john(3, 20); 
	cout << "John's Interval = ";
	john.Print();
	cout << "John's Speed = " << Speed(500, john) << endl;

	cout << "Number of Intervals = " 
	     << Interval::Count() //calling static member function
	     << endl;
	
	cout << "Destroying John's Interval" << endl;
	cout << "Destroying Jack's Interval" << endl;
}

