class GenMethodTest2{

	private static<T extends Comparable<T>> T greater(T first, T second){
		if(first.compareTo(second) > 0)
			return first;
		return second;
	}
	
	public static void main(String[] args){
		double gd = greater(6.78, 5.67);
		System.out.printf("Greater double = %s%n", gd);
		String gs = greater("Monday", "Tuesday");
		System.out.printf("Greater String = %s%n", gs);
		Interval gi = greater(new Interval(3, 45), new Interval(4, 56));
		System.out.printf("Greater Interval = %s%n", gi);
	}
}

