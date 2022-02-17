import java.util.concurrent.*;

class ForkJoinTest{

	static class Computation extends RecursiveTask<Integer>{

		private int low, high;

		Computation(int l, int h){
			low = l;
			high = h;
		}

		@Override
		public Integer compute(){
			if(high - low > 5){
				int mid = (low + high) / 2;
				Computation left = new Computation(low, mid);
				Computation right = new Computation(mid + 1, high);
				right.fork();
				return left.compute() + right.join();
			}
			int result = 0;
			for(int value = low; value <= high; ++value){
				System.out.printf("Processing value %d in thread<%x>%n", value, Thread.currentThread().hashCode());
				result += value * Worker.doWork(value);
			}
			return result;
		}
	}

	public static void main(String[] args) throws Exception{
		ForkJoinPool pool = new ForkJoinPool();
		Computation c = new Computation(1, 20);
		int r = pool.invoke(c);
		System.out.printf("Result = %d%n", r);
	}
}

