package edu.met.banking;

public abstract class Account{

	String id;
	protected double balance;

	public String getId(){
		return id;
	}

	public double getBalance(){
		return balance;
	}

	public abstract void deposit(double amount);

	public abstract void withdraw(double amount) throws InsufficientFundsException;

	public final void transfer(double amount, Account other) throws InsufficientFundsException{
		if(this != other){
			this.withdraw(amount);
			other.deposit(amount);
		}
	}
}

