class AutoBoxTest2{

	/*
	private static String select(int sign, String first, String second){
		if(sign < 0)
			return first;
		return second;
	}

	private static Interval select(int sign, Interval first, Interval second){
		if(sign < 0)
			return first;
		return second;
	}
	*/

	private static Object select(int sign, Object first, Object second){
		if(sign < 0)
			return first;
		return second;
	}
	
	public static void main(String[] args){
		int s = Integer.parseInt(args[0]);
		String ss = (String)select(s, "Monday", "Tuesday");
		System.out.printf("Selected String = %s%n", ss);
		Interval si = (Interval)select(s, new Interval(3, 45), new Interval(2, 10));
		System.out.printf("Selected Interval = %s%n", si);
		double sd = (double)select(s, 4.56, 5.67);
		System.out.printf("Selected double = %s%n", sd);
		long sl = (long)select(s, 123456L, "ABCDEFL");
		System.out.printf("Selected long = %s%n", sl);
	}
}

