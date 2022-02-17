class AutoBoxTest1{

	private static Double getSharePrice(String symbol){
		String[] symbols = {"APPL", "GOGL", "INTC", "MSFT", "ORCL"};
		for(String entry : symbols){
			if(entry.equals(symbol)){
				double price = 0.01 * (1000 + System.currentTimeMillis() % 9000);
				return price; //Boxing: Double.valueOf(price)
			}
		}
		return null;
	}

	public static void main(String[] args){
		Double result = getSharePrice(args[0]);
		if(result == null)
			System.out.println("No such symbol!");
		else{
			double price = result; //Unboxing: result.doubleValue()
			System.out.printf("Share-price: %.2f%n", price);
		}
	}
}

