#include <iostream>

using namespace std;

//////////////////////////////////////////////////////

class Interval
{
public: 
	Interval(long t=0)
	{
		time = t;
	}

	Interval(long m, long s)
	{
		time = 60 * m + s;
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

	//overloading binary addition operator
	Interval operator+(const Interval& other) const
	{
		return Interval(time + other.time);
	}

	//overloading unary prefix-increment operator
	Interval operator++() 
	{
		return Interval(++time);
	}

	//overloading unary postfix-increment operator
	Interval operator++(int)
	{
		return Interval(time++);
	}
private: 
	long time;

//friend function: a global function defined by the author of a class
//		   which has access to private members of that class
friend Interval operator*(long, const Interval&);
};

Interval operator*(long lhs, const Interval& rhs)
{
	return Interval(lhs * rhs.time);
}


////////////////////////////////////////////////////////

int main(void)
{
	Interval a(5, 45);
	a.Print();

	Interval b(1, 90);
	b.Print();

	Interval c = a + b; //a.operator+(b)
	c.Print();

	Interval d = 3 * a; //operator*(3, c)
	d.Print();

	Interval e = ++a; //a.operator++()
	e.Print();
	a.Print();

	Interval f = b++; //b.operator++(0)
	f.Print();
	b.Print();
}

