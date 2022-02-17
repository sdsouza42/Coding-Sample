#include "interval.h"
#include <iostream>
#include <list>
#include <vector>
#include <algorithm>

using namespace std;

bool Compare(const Interval& x, const Interval& y)
{
	return x.Seconds() < y.Seconds();
}

int main(void)
{
	list<Interval> store;
	store.push_back(Interval(3, 41));
	store.push_back(Interval(6, 12));
	store.push_back(Interval(5, 23));
	store.push_back(Interval(2, 34));
	store.push_back(Interval(4, 55));

	vector<Interval> sorted(store.size());
	copy(store.begin(), store.end(), sorted.begin());
	sort(sorted.begin(), sorted.end(), Compare);
	copy(sorted.begin(), sorted.end(), store.begin());

	for(list<Interval>::iterator i = store.begin(); i != store.end(); ++i)
	{
		cout << *i << "\t" << i->GetTime() << endl;
	}

}

