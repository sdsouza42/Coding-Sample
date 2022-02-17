#ifndef BANKING2_H
#define BANKING2_H

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
	protected: 
		Account();
		double balance;
	private:
		long id;
	};

	class Profitable
	{
	public:
		virtual double AddInterest(short) = 0;
		virtual ~Profitable(){}
	};

	//factory functions
	Account* OpenCurrentAccount(void);
	Account* OpenSavingsAccount(void);
	void CloseAccount(Account*);
}

#endif


