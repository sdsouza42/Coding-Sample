class GenMethodTest1{

	private static<T> T select(int sign, T first, T second){
		if(sign < 0)
			return first;
		return second;
	}
	
	public static void main(String[] args){
		int s = Integer.parseInt(args[0]);
		String ss = select(s, "Monday", "Tuesday");
		System.out.printf("Selected String = %s%n", ss);
		Interval si = select(s, new Interval(3, 45), new Interval(2, 10));
		System.out.printf("Selected Interval = %s%n", si);
		double sd = select(s, 4.56, 5.67);
		System.out.printf("Selected double = %s%n", sd);
		long sl = select(s, 123456L, 0xABCDEFL);
		System.out.printf("Selected long = %s%n", sl);
	}
}

