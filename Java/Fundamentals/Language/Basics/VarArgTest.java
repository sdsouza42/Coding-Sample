class VarArgTest{

	private static double average(double first, double second){
		return (first + second) / 2;
	}

	//overloaded average
	private static double average(double first, double second, double third){
		return (first + second + third) / 3;
	}

	//variadic (vararg) average
	private static double average(double first, double second, double... remaining){
		double total = first + second;
		for(double value : remaining)
			total += value;
		return total / (remaining.length + 2);
	}

	public static void main(String[] args){
		System.out.printf("Average of two values = %f%n", average(23.4, 29.7));
		System.out.printf("Average of three values = %f%n", average(23.4, 29.7, 25.3));
		System.out.printf("Average of five values = %f%n", average(23.4, 29.7, 25.3, 31.2, 19.8));
	}
}

