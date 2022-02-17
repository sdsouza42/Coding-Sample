import java.util.stream.*;

class ParallelStreamTest{

	private static int processValue(int value){
		System.out.printf("Processing value %d in thread<%x>%n", value, Thread.currentThread().hashCode());
		return value * Worker.doWork(value);
	}

	public static void main(String[] args) throws Exception{
		int r = IntStream.range(1, 21)
				 .parallel()
				 .map(ParallelStreamTest::processValue)
				 .sum();
		System.out.printf("Result = %d%n", r);
	}
}

