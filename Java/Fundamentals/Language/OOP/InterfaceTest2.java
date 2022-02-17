//Functional interface: Interface with only one abstract method
interface Filter{
	boolean allowed(int value);
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
	}
}

class InterfaceTest2{

	//Nested inner member class
	//It can only reference static members of outer class
	//It can define static and non-static members
	static class OddFilter implements Filter{
		
		public boolean allowed(int n){
			return (n % 2) == 1;
		}
	}

	//Inner member class
	//It can reference static and non-static members of outer class
	//It can only define non-static members
	class BetweenFilter implements Filter{
		
		private int low, high;

		BetweenFilter(int l, int h){
			low = l;
			high = h;
		}

		public boolean allowed(int n){
			return (n > low) && (n < high);
		}
	}

	public static void main(String[] args){
		int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
		Algorithm.printSquares("All squares", numbers);
		Algorithm.printSquaresIf("Odd squares", numbers, new InterfaceTest2.OddFilter());
		Algorithm.printSquaresIf("Mid squares", numbers, new InterfaceTest2().new BetweenFilter(3, 8));
		int l = 5; //effectively final as it is referenced in local class
		//creating object of an anonymous local inner class that implements Filter
		Algorithm.printSquaresIf("Big squares", numbers, new Filter(){
			public boolean allowed(int n){
				return n > l; //l is read-only 
			}
		});
	}
}

