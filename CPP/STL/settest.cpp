#include "interval.h"
#include <iostream>
#include <set>
#include <functional>

using namespace std;

bool operator>(const Interval& x, const Interval& y)
{
	return y < x;
}

int main(void)
{
	//set<Interval> store;
	set<Interval, greater<Interval> > store;
	store.insert(Interval(3, 41));
	store.insert(Interval(6, 12));
	store.insert(Interval(5, 23));
	store.insert(Interval(2, 34));
	store.insert(Interval(4, 55));
	store.insert(Interval(1, 94));

	for(set<Interval>::iterator i = store.begin(); i != store.end(); ++i)
	{
		cout << *i << "\t" << i->GetTime() << endl;
	}

}

