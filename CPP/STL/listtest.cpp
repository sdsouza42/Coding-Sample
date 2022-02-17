#include "interval.h"
#include <iostream>
#include <list>

using namespace std;

int main(void)
{
	list<Interval> store;
	store.push_back(Interval(3, 41));
	store.push_back(Interval(6, 12));
	store.push_back(Interval(5, 23));
	store.push_back(Interval(2, 34));
	store.push_back(Interval(4, 55));
	store.push_front(Interval(1, 20));

	for(list<Interval>::iterator i = store.begin(); i != store.end(); ++i)
	{
		cout << *i << "\t" << i->GetTime() << endl;
	}

	list<Interval>::iterator j = store.end();
	--j;--j;--j;
	cout << "Fourth Interval = " << *j << endl;

}

