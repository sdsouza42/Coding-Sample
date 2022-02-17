#ifndef BANKING1_H
#define BANKING1_H

#include <ctime>

namespace Banking
{
	class InsufficientFunds {};

	class Account
	{
	public:
		long Id() const;
		double Balance() const;
		virtual void Deposit(double) = 0; 
		virtual void Withdraw(double) throw(InsufficientFunds) = 0;
		void Transfer(double, Account*) throw(InsufficientFunds);
		virtual ~Account(){}
	protected: //members in this block are visible to derived classes
		Account();
		double balance;
	private:
		long id;
	};

	class CurrentAccount : public Account
	{
	public:
		void Deposit(double);
		void Withdraw(double) throw(InsufficientFunds);
	};

	class SavingsAccount : public Account
	{
	public:
		SavingsAccount();
		void Deposit(double);
		void Withdraw(double) throw(InsufficientFunds);
		double AddInterest(short);
	};
}

#endif


