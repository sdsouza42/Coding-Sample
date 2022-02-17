#include "interval.h"
#include <iostream>
#include <vector>
#include <algorithm>
#include <numeric>

using namespace std;

Interval Combine(const Interval& x, const Interval& y)
{
	long m = x.Minutes() + y.Minutes();
	long s = x.Seconds() + y.Seconds();

	return Interval(m, s);
}

int main(void)
{
	vector<Interval> store;
	store.push_back(Interval(3, 41));
	store.push_back(Interval(6, 12));
	store.push_back(Interval(5, 23));
	store.push_back(Interval(2, 34));
	store.push_back(Interval(4, 55));

	for(vector<Interval>::iterator i = store.begin(); i != store.end(); ++i)
	{
		cout << *i << "\t" << i->GetTime() << endl;
	}

	Interval total = accumulate(store.begin(), store.end(), Interval(0, 0), Combine);
	cout << "Total Interval = " << total << endl;
}

