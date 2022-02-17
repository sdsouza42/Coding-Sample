#include <iostream>

using namespace std;

//////////////////////////////////////////////////////

class Interval
{
public:
	explicit Interval(long m=0, long s=0)
	{
		minutes = m + s / 60;
		seconds = s % 60;
		cout << "Interval object created" << endl;
	}

	void SetTime(long value)
	{
		minutes = value / 60;
		seconds = value % 60;
	}

	long GetTime() const
	{
		return 60 * minutes + seconds;	
	}

	void Print() const
	{
		if(seconds < 10)
			cout << minutes << ":0" << seconds << endl;
		else
			cout << minutes << ":" << seconds << endl;
	}

	~Interval()
	{
		cout << "Interval object destroyed" << endl;
	}
private: 
	long minutes;
	long seconds;
};


//////////////////////////////////////////////////////

float Speed(float distance, const Interval* duration)
{
	return 3.6 * distance / duration->GetTime();
}

int main(void)
{
	int n;
	cout << "Number of Intervals: ";
	cin >> n;

	//dynamically allocate an array of n Interval objects
	//and call default constructor on each of these objects
	Interval* intervals = new Interval[n];

	for(int i = 0; i < n; ++i)
	{
		intervals[i].SetTime(50 * i + 72);
		intervals[i].Print();
	}

	//call destructor on each object in the array and deallocate the array
	delete[] intervals;
}


