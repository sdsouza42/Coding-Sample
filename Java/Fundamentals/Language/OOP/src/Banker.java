package edu.met.banking;

public class Banker{

	private static long nid = System.currentTimeMillis() % 1000000;

	private Banker(){}

	public static Account openCurrentAccount(){
		CurrentAccount acc = new CurrentAccount();
		acc.id = "C/A" + nid++;
		return acc;
	}

	public static Account openSavingsAccount(){
		SavingsAccount acc = new SavingsAccount();
		acc.id = "S/A" + nid++;
		return acc;
	}
}

