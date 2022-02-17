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

	//copy constructor
	Interval(const Interval& other)
	{
		time = other.time;
		cout << "Interval object copy created" << endl;
	}

	//overloading assignment operator
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

	//overloading conversion operator
	operator float() const
	{
		return time / 60.0;
	}

	//overloading subscript operator
	long operator[](int index) const
	{
		return index ? (time / 60) : (time % 60);
	}


private: 
	long time;

};



////////////////////////////////////////////////////////

int main(void)
{
	Interval a(4, 30); //created using parameterized constructor 
	a.Print();
	float b = a;
	cout << b << endl;
	cout << a[1] << " minutes and " << a[0] << " seconds." << endl;

	Interval c = a; //created using copy constructor
	c.Print();

	Interval d; //created using default constructor
	d = a; //d.operator=(a)
	d.Print();
}

