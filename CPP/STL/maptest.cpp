#include "interval.h"
#include <iostream>
#include <string>
#include <map>

using namespace std;

int main(void)
{
	map<string, Interval> store;
	store.insert(make_pair("monday", Interval(3, 41)));
	store.insert(make_pair("tuesday", Interval(6, 12)));
	store.insert(make_pair("wednesday", Interval(5, 23)));
	store.insert(make_pair("thursday", Interval(2, 34)));
	store.insert(make_pair("friday", Interval(4, 55)));
	store.insert(make_pair("tuesday", Interval(6, 16)));

	for(map<string, Interval>::iterator i = store.begin(); i != store.end(); ++i)
	{
		cout << i->first << " => " << i->second << endl;
	}

	string key;
	cout << "Key: ";
	cin >> key;

	map<string, Interval>::iterator j = store.find(key);
	if(j != store.end())
		cout << "Value = " << j->second << endl;
	else
		cout << "No such key!" << endl;
}

