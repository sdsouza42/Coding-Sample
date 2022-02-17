import finance.*;

class AnnotationTest1{

	public static void main(String[] args) throws Exception{
		double p = Double.parseDouble(args[0]);
		Class<?> c = Class.forName(args[1]);
		boolean rb = c.isAnnotationPresent(ReducingBalance.class);
		LoanPolicy pol = (LoanPolicy)c.newInstance();
		int m = 10;
		for(int n = 1; n <= m; ++n){
			float r = pol.interestRate(p, n);
			double emi;
			if(rb){
				float i = r / 1200;
				emi = p * i / (1 - Math.pow(1 + i, -12 * n));
			}else{
				emi = p * Math.pow(1 + r / 100, n) / (12 * n);
			}
			System.out.printf("%d\t%.2f%n", n, emi);
		}
		if(rb)
			System.out.println("Using reducing-balance method.");
	}
}

