interface Filter{
	//non-overriding abstract method
	boolean allowed(int value);

	//overriding abstract method
	default int countAllowed(int[] values){
		int count = 0;
		for(int value : values){
			if(allowed(value))
				count += 1;
		}
		return count;
	}
}

class Algorithm{

	public static void printSquares(String label, int[] values){
		System.out.printf("%s:", label);
		for(int value : values){
			System.out.printf(" %d", value * value);
		}
		System.out.println();
	}

	public static void printSquaresIf(String label, int[] values, Filter check){
		System.out.printf("%s:", label);
		for(int value : values){
			if(check.allowed(value))
				System.out.printf(" %d", value * value);
		}
		System.out.println();
		System.out.printf("Printed %d value/s%n", check.countAllowed(values));
	}
}

class LambdaTest{

	private static boolean isOdd(int n){
		return (n % 2) == 1;
	}

	public static void main(String[] args){
		int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
		Algorithm.printSquares("All squares", numbers);
		//passing method-reference
		Algorithm.printSquaresIf("Odd squares", numbers, LambdaTest::isOdd);
		int l = 5; //effectively final
		//passing lambda-expression
		Algorithm.printSquaresIf("Big squares", numbers, n -> n > l);
	}
}

