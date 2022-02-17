class ArrayHelper{

	public native static double sumOf(double[] values);

	public native static void squareAll(double[] values); 

	static{
		System.loadLibrary("arrh");
	}
}

class ArrayAccessTest{

	public static void main(String[] args){
		double[] list = new double[args.length];
		for(int i = 0; i < args.length; ++i)
			list[i] = Double.parseDouble(args[i]);
		System.out.printf("Sum of values : %f%n", ArrayHelper.sumOf(list));
		ArrayHelper.squareAll(list);
		System.out.printf("Sum of squares: %f%n", ArrayHelper.sumOf(list));
	}
}

