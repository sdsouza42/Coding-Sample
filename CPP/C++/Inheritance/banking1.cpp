#include "banking1.h"

namespace Banking
{
	long Account::Id() const
	{
		return id;
	}

	double Account::Balance() const
	{
		return balance;
	}

	void Account::Transfer(double amount, Account* that) throw(InsufficientFunds)
	{
		if(this != that)
		{
			this->Withdraw(amount);
			that->Deposit(amount);
		}
	}

	Account::Account()
	{
		static long nid = std::time(0) % 10000;

		id = nid++;
		balance = 0;
	}

	void CurrentAccount::Deposit(double amount)
	{
		if(balance < 0)
			amount *= 0.9;
		balance += amount;
	}

	void CurrentAccount::Withdraw(double amount) throw(InsufficientFunds)
	{
		balance -= amount;
	}

	SavingsAccount::SavingsAccount()
	{
		balance = 5000;
	}

	void SavingsAccount::Deposit(double amount)
	{
		balance += amount;
	}

	void SavingsAccount::Withdraw(double amount) throw(InsufficientFunds)
	{
		if(balance - amount < 5000)
			throw InsufficientFunds();

		balance -= amount;
	}

	double SavingsAccount::AddInterest(short period)
	{
		float rate = balance < 10000 ? 4 : 5;
		double interest = balance * period * rate / 100;

		balance += interest;

		return interest;
	}
}

