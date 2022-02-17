#include "simplelist.h"
#include "interval.h"
#include <iostream>

using namespace Generic;
using namespace std;

template<typename E, bool LIFO=false>
class SimpleListAdapter
{
public:
	void Insert(const E& element)
	{
		container.AddElement(element, LIFO);
	}

	bool Extract(E& element)
	{
		if(container.HasElements())
		{
			element = container.FirstElement();
			container.RemoveElement();
			return true;
		}

		return false;
	}
private:
	SimpleList<E> container;
};

int main(void)
{
	//SimpleListAdapter<Interval> store;
	SimpleListAdapter<Interval, true> store;
	store.Insert(Interval(3, 41));
	store.Insert(Interval(5, 12));
	store.Insert(Interval(7, 53));
	store.Insert(Interval(2, 34));
	store.Insert(Interval(6, 25));

	Interval entry;
	while(store.Extract(entry))
	{
		cout << entry << endl;
	}
}

