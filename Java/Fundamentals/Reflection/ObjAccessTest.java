import java.lang.reflect.*;

class ObjAccessTest{

	/*
	private static void printAsXml(Interval obj){
		System.out.println("<Interval>");
		System.out.printf("  <minutes>%s</minutes>%n", obj.minutes());
		System.out.printf("  <seconds>%s</seconds>%n", obj.seconds());
		System.out.println("</Interval>");
		System.out.println();
	}

	private static void printAsXml(payroll.Employee obj){
		System.out.println("<Employee>");
		System.out.printf("  <id>%s</id>%n", obj.getId());
		System.out.printf("  <hours>%s</hours>%n", obj.getHours());
		System.out.printf("  <rate>%s</rate>%n", obj.getRate());
		System.out.println("</Employee>");
		System.out.println();
	}
	*/

	private static void printAsXml(Object obj){
		Class<?> c = obj.getClass();
		System.out.printf("<%s>%n", c.getSimpleName());
		for(Field fld : c.getDeclaredFields()){
			int m = fld.getModifiers();
			if(Modifier.isStatic(m)) continue;
			System.out.printf("  <%s>", fld.getName());
			try{
				fld.setAccessible(true);
				System.out.print(fld.get(obj));
			}catch(Exception e){
				System.out.print(e);
			}
			System.out.printf("</%s>%n", fld.getName());
		}
		System.out.printf("</%s>%n", c.getSimpleName());
		System.out.println();
	}

	public static void main(String[] args){
		printAsXml(new Interval(3, 45));
		printAsXml(new payroll.Employee(186, 52));
	}
}

