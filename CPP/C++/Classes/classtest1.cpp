#include <iostream>

using namespace std;

//////////////////////////////////////////////////////

class Interval
{
public: 
//following members are accessible in and out of this class

	void SetTime(long value) // void Interval::SetTime(Interval* this, long value)
	{
		minutes = value / 60; //this->minutes = value / 60;
		seconds = value % 60; //this->seconds = value % 60;
	}

	long GetTime()
	{
		return 60 * minutes + seconds;	
	}

	void Print()
	{
		if(seconds < 10)
			cout << minutes << ":0" << seconds << endl;
		else
			cout << minutes << ":" << seconds << endl;
	}

private: 
//following members are only accessible in this class

	long minutes;
	long seconds;
};


//////////////////////////////////////////////////////

float Speed(float distance, Interval duration)
{
	return 3.6 * distance / duration.GetTime();
}

int main(void)
{
	Interval jack; //instatiating Interval class
	jack.SetTime(125); //Interval::SetTime(&jack, 125);
	cout << "Jack's Interval = ";
	jack.Print();
	cout << "Jack's Speed = " << Speed(500, jack) << endl;
	
	Interval john;
	john.SetTime(200);//Interval::SetTime(&john, 200);
	cout << "John's Interval = ";
	john.Print();
	cout << "John's Speed = " << Speed(500, john) << endl;
}

