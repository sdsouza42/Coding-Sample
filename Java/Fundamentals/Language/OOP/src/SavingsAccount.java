package edu.met.banking;

final class SavingsAccount extends Account implements Profitable{

	private static final double MIN_BAL = 5000;

	SavingsAccount(){
		balance = MIN_BAL;
	}

	public void deposit(double amount){
		balance += amount;
	}

	public void withdraw(double amount) throws InsufficientFundsException{
		if(balance - amount < MIN_BAL)
			throw new InsufficientFundsException();
		balance -= amount;
	}

	public double addInterest(int period){
		float rate = balance < 2 * MIN_BAL ? 4 : 5 ;
		double interest = balance * period * rate / 100;
		balance += interest;
		return interest;
	}
}

