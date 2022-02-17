class SomeResource implements AutoCloseable{

	private String id = null;

	static{
		System.out.println("SomeResource class initialized.");
	}

	SomeResource(String name){
		id = name;
		System.out.printf("%s resource acquired%n", id);
	}

	public void consume(){
		if(id != null)
			System.out.printf("%s resource consumed%n", id);
	}

	public void close(){
		if(id != null){
			System.out.printf("%s resource released%n", id);
			id = null;
		}
	}

	public void finalize(){
		close();
	}
}


class GCTest{

	private static void run(){
		SomeResource b = new SomeResource("Second");
		b.consume();
	}

	public static void main(String[] args){
		SomeResource a = new SomeResource("First");
		run();
		a.consume();
		a.close();
		System.gc();
		try(SomeResource c = new SomeResource("Third")){
			c.consume();
		}
	}
}

