#include "interval.h"
#include <iostream>
#include <queue>
#include <vector>
#include <functional>
#include <utility>

using namespace std;
using rel_ops::operator>;

int main(void)
{
	//priority_queue<Interval> store;
	priority_queue<Interval, vector<Interval>, greater<Interval> > store;
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

