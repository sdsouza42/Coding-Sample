#include "banking2.h"
#include <iostream>

using namespace Banking;
using namespace std;

void PayAnnualInterest(Account* accounts[], int count)
{
	for(int i = 0; i < count; ++i)
	{
		Profitable* p = dynamic_cast<Profitable*>(accounts[i]);
		if(p)
			p->AddInterest(1);
	}
}

int main(void)
{
	Account* bank[4];
	bank[0] = OpenCurrentAccount();
	bank[0]->Deposit(20000);
	bank[1] = OpenSavingsAccount();
	bank[1]->Deposit(25000);
	bank[2] = OpenSavingsAccount();
	bank[2]->Deposit(35000);
	bank[3] = OpenCurrentAccount();
	bank[3]->Deposit(50000);

	PayAnnualInterest(bank, 4);

	for(int i = 0; i < 4; ++i)
	{
		cout << bank[i]->Id() << '\t' << bank[i]->Balance() << endl;
		CloseAccount(bank[i]);
	}

}
