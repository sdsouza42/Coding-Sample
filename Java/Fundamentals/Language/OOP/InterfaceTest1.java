import edu.met.banking.*;

class InterfaceTest1{

	private static void payAnnualInterest(Account[] accounts){
		for(Account acc : accounts){
			if(acc instanceof Profitable){
				Profitable p = (Profitable)acc;
				p.addInterest(1);
			}
		}
	}

	public static void main(String[] args){
		Account[] bank = new Account[4];
		bank[0] = Banker.openSavingsAccount();
		bank[0].deposit(15000);
		bank[1] = Banker.openCurrentAccount();
		bank[1].deposit(30000);
		bank[2] = Banker.openCurrentAccount();
		bank[2].deposit(40000);
		bank[3] = Banker.openSavingsAccount();
		bank[3].deposit(45000);
		payAnnualInterest(bank);
		for(Account acc : bank){
			System.out.printf("%s\t%.2f%n", acc.getId(), acc.getBalance());
		}
	}
}

