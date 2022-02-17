#ifndef INTERVAL_H
#define INTERVAL_H

#include <iostream>

class Interval
{
public:
	explicit Interval(long m=0, long s=0)
	{
		minutes = m + s / 60;
		seconds = s % 60;
	}

	long Minutes() const
	{
		return minutes;
	}

	long Seconds() const
	{
		return seconds;
	}

	long GetTime() const
	{
		return 60 * minutes + seconds;
	}

	void SetTime(long value)
	{
		minutes = value / 60;
		seconds = value % 60;
	}

	bool operator==(const Interval& other) const
	{
		return (minutes == other.minutes) && (seconds == other.seconds);
	}

	bool operator<(const Interval& other) const
	{
		return (60 * minutes + seconds) < (60 * other.minutes + other.seconds);
	}
private:
	long minutes;
	long seconds;

friend std::ostream& operator<<(std::ostream&, const Interval&);
friend std::istream& operator>>(std::istream&, Interval&);
};

std::ostream& operator<<(std::ostream& out, const Interval& val)
{
	if(val.seconds < 10)
		out << val.minutes << "0:" << val.seconds;
	else
		out << val.minutes << ":" << val.seconds;
	
	return out;
}

std::istream& operator>>(std::istream& in, Interval& val)
{
	long m, s;
	char c;

	in >> m >> c >> s;
	val.minutes = m + s / 60;
	val.seconds = s % 60;

	return in;
}

#endif














