class StringHelper{

	public native static int hashOf(String str);

	public native static String reverseOf(String str);

	static{
		System.loadLibrary("strh");
	}
}

class StringAccessTest{

	public static void main(String[] args) throws Exception{
		System.out.printf("Original string: %s%n", args[0]);
		System.out.printf("Hash of string : %x%n", StringHelper.hashOf(args[0]));
		System.out.printf("Reversed string: %s%n", StringHelper.reverseOf(args[0]));
	}
}

