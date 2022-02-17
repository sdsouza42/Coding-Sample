class ThreadSleepTest{

	static class GreeterThread extends Thread{
		
		private String message;
		private int count;

		GreeterThread(String m, int n){
			message = m;
			count = n;
			start();
		}

		@Override
		public void run(){
			for(int i = 1; i <= count; ++i){
				System.out.printf("%s:%d from thread<%x>%n", message, i, Thread.currentThread().hashCode());
				Worker.doWork(i);
			}
			try{
				Thread.sleep(15000);
			}catch(InterruptedException e){
				System.out.println("Sleep interrupted!");
			}
			System.out.println("Goodbye.");
		}

	}

	public static void main(String[] args) throws Exception{
		Thread child = new GreeterThread("Hello", 8);
		for(int i = 12; i > 0; i--){
			System.out.printf("Welcome:%d from thread<%x>%n", i, Thread.currentThread().hashCode());
			Worker.doWork(i);
		}
		child.interrupt();
	}
}

