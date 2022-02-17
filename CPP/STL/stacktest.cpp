#include "interval.h"
#include <iostream>
#include <stack>
#include <list>

using namespace std;

int main(void)
{
	//stack<Interval> store;
	stack<Interval, list<Interval> > store;
	store.push(Interval(3, 41));
	store.push(Interval(6, 12));
	store.push(Interval(5, 23));
	store.push(Interval(2, 34));
	store.push(Interval(4, 55));

	while(!store.empty())
	{
		cout << store.top() << endl;
		store.pop();
	}

}

