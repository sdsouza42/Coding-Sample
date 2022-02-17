class ObjMethodTest{

	public static void main(String[] args){
		Interval a = new Interval(7, 45);
		Interval b = new Interval(4, 21);
		Interval c = new Interval(6, 105);
		Interval d = b;//a.add(b);
		System.out.printf("Interval a = %s%n", a);
		System.out.printf("Interval b = %s%n", b);
		System.out.printf("Interval c = %s%n", c);
		System.out.printf("Interval d = %s%n", d);
		System.out.printf("a is identical to b: %b%n", a == b);
		System.out.printf("a is identical to c: %b%n", a == c);
		System.out.printf("d is identical to b: %b%n", d == b);
		System.out.printf("Hash-code of a = %x%n", a.hashCode());
		System.out.printf("Hash-code of b = %x%n", b.hashCode());
		System.out.printf("Hash-code of c = %x%n", c.hashCode());
		System.out.printf("Hash-code of d = %x%n", d.hashCode());
		System.out.printf("a is equal to b: %b%n", a.equals(b));
		System.out.printf("a is equal to c: %b%n", a.equals(c));
		System.out.printf("d is equal to b: %b%n", d.equals(b));
	}
}

