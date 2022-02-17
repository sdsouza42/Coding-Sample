#include <iostream>
#include <string>

using namespace std;

struct BadName {};

int Search(string entry, string entries[], int count) throw(BadName, string)
{
	if(entry.size() < 4)
	{
		BadName bn;
		throw bn;
	}

	for(int i = 0; i < count; ++i)
	{
		if(entries[i] == entry)
			return i;
	}

	throw entry;
}

void Run(void)
{
	string names[] = {"jack", "jill", "jane", "jeff", "john"};
	long balances[] = {9000, 11500, 23750, 12250, 4000};

	string name;
	cout << "Name: ";
	cin >> name;

	try
	{
		int i = Search(name, names, 5);
		cout << "Balance: " << balances[i] << endl;
	}
	catch(string s)
	{
		cout << "Name not found: " << s << endl;
	}
	catch(BadName)
	{
		cout << "Name too small" << endl;
	}
}


int main(void)
{
	cout << "Welcome to our Bank" << endl;

	Run();

	cout << "Goodbye from our Bank" << endl;
}

