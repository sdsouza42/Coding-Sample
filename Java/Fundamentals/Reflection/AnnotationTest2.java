import finance.*;
import java.lang.reflect.*;

class AnnotationTest2{

	public static void main(String[] args) throws Exception{
		double p = Double.parseDouble(args[0]);
		Class<?> c = Class.forName(args[1]);
		Method meth = c.getMethod(args[2], double.class, int.class);
		MaxDuration md = meth.getAnnotation(MaxDuration.class);
		Object pol = c.newInstance();
		int m = md != null ? md.value() : 10;
		for(int n = 1; n <= m; ++n){
			float r = (float)meth.invoke(pol, p, n);
			double emi;
			emi = p * Math.pow(1 + r / 100, n) / (12 * n);
			System.out.printf("%d\t%.2f%n", n, emi);
		}
	}
}

