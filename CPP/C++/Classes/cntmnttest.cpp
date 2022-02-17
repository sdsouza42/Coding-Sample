#include <iostream>

using namespace std;

//////////////////////////////////////////////////////

class Interval
{
public: 
	explicit Interval(long m=0, long s=0)
	{
		time = 60 * m + s;
		cout << "Interval object created" << endl;
	}

	Interval(const Interval& other)
	{
		time = other.time;
		cout << "Interval object copy created" << endl;
	}

	void operator=(const Interval& other)
	{
		time = other.time;
		cout << "Interval object assigned" << endl;
	}

	~Interval()
	{
		cout << "Interval object destroyed" << endl;
	}

	void SetTime(long value) 
	{
		time = value;
	}

	long GetTime() const
	{
		return time;
	}

	void Print() const
	{
		if((time % 60) < 10)
			cout << (time / 60) << ":0" << (time % 60) << endl;
		else
			cout << (time / 60) << ":" << (time % 60) << endl;
	}

private: 
	long time;

};

#ifdef _AGGREGATION

class Journey
{
public:
	Journey(float dis, const Interval& dur)
	{
		distance = dis;
		duration = &dur;
		cout << "Journey object created" << endl;
	}

	float Speed() const
	{
		return 3.6 * distance / duration->GetTime();
	}

	~Journey()
	{
		cout << "Journey object destroyed" << endl;
	}

private:
	float distance;
	const Interval* duration;
};

#else

class Journey
{
public:
	Journey(float dis, const Interval& dur) : duration(dur)
	{
		distance = dis;
		//duration = dur;
		cout << "Journey object created" << endl;
	}

	float Speed() const
	{
		return 3.6 * distance / duration.GetTime();
	}

	~Journey()
	{
		cout << "Journey object destroyed" << endl;
	}

private:
	float distance;
	Interval duration;
};

#endif

////////////////////////////////////////////////////////

Interval i;

void Run(void)
{
	Journey j(750, i);
	cout << "Speed = " << j.Speed() << endl;
}

int main(void)
{
	long m, s;
	cout << "Enter minutes and seconds: ";
	cin >> m >> s;
	i.SetTime(60 * m + s);

	cout << "Journey begins..." << endl;
	Run();
	cout << "Journey ends." << endl;
}



