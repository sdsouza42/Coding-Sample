class TryCatchTest{

	private static void run(String[] args){
		System.out.println("Welcome User.");
		try{
			double value = Double.parseDouble(args[0]);
			System.out.printf("Square of %f is %f%n", value, value * value);
		}catch(NumberFormatException e){
			System.out.println("Bad input");
		}catch(ArrayIndexOutOfBoundsException e){
			System.out.println("No input");
		}
		System.out.println("Goodbye User.");
	}

	public static void main(String[] args){
		run(args);
	}
}

