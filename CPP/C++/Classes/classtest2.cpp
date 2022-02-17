#include <iostream>

using namespace std;

//////////////////////////////////////////////////////

class Interval
{
public: 

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


//////////////////////////////////////////////////////

float Speed(float distance, Interval duration)
{
	return 3.6 * distance / duration.GetTime();
}

int main(void)
{
	Interval jack;
	jack.SetTime(125); 
	cout << "Jack's Interval = ";
	jack.Print();
	cout << "Jack's Speed = " << Speed(500, jack) << endl;
	
	Interval john;
	john.SetTime(200);
	cout << "John's Interval = ";
	john.Print();
	cout << "John's Speed = " << Speed(500, john) << endl;
}

