#include "interval.h"
#include <iostream>
#include <queue>
#include <list>

using namespace std;

int main(void)
{
	//queue<Interval> store;
	queue<Interval, list<Interval> > store;
	store.push(Interval(3, 41));
	store.push(Interval(6, 12));
	store.push(Interval(5, 23));
	store.push(Interval(2, 34));
	store.push(Interval(4, 55));

	while(!store.empty())
	{
		cout << store.front() << endl;
		store.pop();
	}

}

