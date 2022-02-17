#include "banking1.h"
#include <iostream>

using namespace Banking;
using namespace std;

int main(void)
{
	CurrentAccount* jack = new CurrentAccount;
	jack->Deposit(15000);
	SavingsAccount* jill = new SavingsAccount;
	jill->Deposit(10000);

	double amt;
	cout << "Enter amount to transfer: ";
	cin >> amt;

	try
	{
		jill->Transfer(amt, jack);
		cout << "Transfer succeeded." << endl;
	}
	catch(InsufficientFunds)
	{
		cout << "Transfer failed!" << endl;
	}

	cout << "Jack's Account ID is "
	     << jack->Id()
	     << " and Balance is "
	     << jack->Balance()
	     << endl;
	cout << "Jill's Account ID is "
	     << jill->Id()
	     << " and Balance is "
	     << jill->Balance()
	     << endl;

	delete jill;
	delete jack;
}

