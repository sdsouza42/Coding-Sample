#include <iostream>
#include <string>

using namespace std;

struct BadName {};

int Search(string entry, string entries[], int count)
{
	if(entry.size() < 4)
	{
		BadName bn;
		throw bn; //transfers control to statement which catches BadName (type of bn)
	}

	for(int i = 0; i < count; ++i)
	{
		if(entries[i] == entry)
			return i; //transfers control to statement after the call
	}

	throw entry; //transfers control to statement which catches string (type of entry)
}

void Run(void)
{
	string names[] = {"jack", "jill", "jane", "jeff", "john"};
	long balances[] = {9000, 11500, 23750, 12250, 4000};

	string name;
	cout << "Name: ";
	cin >> name;

	int i = Search(name, names, 5);
	cout << "Balance: " << balances[i] << endl;
}


int main(void)
{
	cout << "Welcome to our Bank" << endl;

	Run();

	cout << "Goodbye from our Bank" << endl;
}

