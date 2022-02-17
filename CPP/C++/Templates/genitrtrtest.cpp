#include "simplelist.h"
#include "interval.h"
#include <iostream>

using namespace Generic;
using namespace std;

int main(void)
{
	SimpleList<Interval> store;
	store.AddElement(Interval(3, 41));
	store.AddElement(Interval(5, 12));
	store.AddElement(Interval(7, 53));
	store.AddElement(Interval(2, 34));
	store.AddElement(Interval(6, 25));
	store.AddElement(Interval(4, 30), true);

	for(SimpleList<Interval>::Iterator i = store.Begin(); i != store.End(); ++i)
	{
		cout << *i << "\t" << i->GetTime() << endl;
	}

}

