class IfElseTest{

	public static void main(String[] args){
		if(args.length == 0){
			System.out.println("Hello World!");
		}else{
			System.out.printf("Hello %s!%n", args[0]);
		}
	}
}

