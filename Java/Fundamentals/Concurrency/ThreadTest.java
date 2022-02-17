class ThreadTest{

	private static void handleJob(int id){
		System.out.printf("Thread<%x> has accepted job:%d%n", Thread.currentThread().hashCode(), id);
		Worker.doWork(id);
		System.out.printf("Thread<%x> has finished job:%d%n", Thread.currentThread().hashCode(), id);
	}

	public static void main(String[] args) throws Exception{
		int n = args.length > 0 ? Integer.parseInt(args[0]) : 50;
		Thread child = new Thread(new Runnable(){
			public void run(){
				handleJob(n);
			}
		});
		child.setDaemon(n > 70);
		child.start();
		handleJob(40);
	}
}

