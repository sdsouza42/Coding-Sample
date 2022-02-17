import java.util.concurrent.*;

class ExecutorTest{

	static class Computation implements Callable<Integer>{

		private int low, high;

		Computation(int l, int h){
			low = l;
			high = h;
		}

		public Integer call(){
			int result = 0;
			for(int value = low; value <= high; ++value){
				System.out.printf("Processing value %d in thread<%x>%n", value, Thread.currentThread().hashCode());
				result += value * Worker.doWork(value);
			}
			return result;
		}
	}

	public static void main(String[] args) throws Exception{
		ExecutorService pool = Executors.newFixedThreadPool(2);
		Computation c1 = new Computation(1, 10);
		Computation c2 = new Computation(11, 20);
		Future<Integer> r1 = pool.submit(c1);
		Future<Integer> r2 = pool.submit(c2);
		int r = r1.get() + r2.get();
		System.out.printf("Result = %d%n", r);
		pool.shutdown();
	}
}

