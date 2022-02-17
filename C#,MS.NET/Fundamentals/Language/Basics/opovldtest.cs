using System;

class Interval
{
	private int time;

	public Interval(int m, int s)
	{
		time = 60 * m + s;
	}

	private Interval(int t)
	{
		time = t;
	}	
	
	public int Time
	{
		get
		{
			return time;
		}

		set
		{
			time = value;
		}
	}


	//expression bodied method
	public void Print() => Console.WriteLine("{0}:{1:00}", time / 60, time % 60);

	public static Interval operator+(Interval lhs, Interval rhs)
	{
		return new Interval(lhs.time + rhs.time);
	}

	public static Interval operator*(int lhs, Interval rhs)
	{
		return new Interval(lhs * rhs.time);
	}

	public static Interval operator++(Interval value)
	{
		return new Interval(value.time + 1);
	}

	public static bool operator<(Interval lhs, Interval rhs)
	{
		return lhs.time < rhs.time;
	}

	public static bool operator>(Interval lhs, Interval rhs)
	{
		return lhs.time > rhs.time;
	}

	public static implicit operator Interval(double value)
	{
		return new Interval((int)(60 * value));
	}

	public static explicit operator double(Interval value)
	{
		return value.time / 60.0;
	}
}

static class Program
{

	public static void Main()
	{
		Interval a = new Interval(4, 30);
		a.Print();

		Interval b = new Interval(2, 105);
		b.Print();

		Interval c = a + b; //Interval.op_addition(a, b)
		c.Print();

		Interval d = 3 * c; //Interval.op_Multilpy(3, c)
		d.Print();

		Interval e = ++d; //d = Interval.op_Increment(d); e = d;
		d.Print();
		e.Print();

		Interval f=e++; //f = e; e = Interval.op_Increment(e);
		e.Print();
		f.Print();

		Interval g = 6.25; //Interval.op_Implicit(6.25)
		g.Print();

		double h = (double)g; //Interval.op_Explicit(g)
		Console.WriteLine(h); 
	}
}
