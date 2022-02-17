import java.util.*;
import java.util.stream.*;

class StreamTest2{

	static class Journey{
		private double distance = 500;
		private Interval period;

		Journey(Interval i){
			period = i;
		}

		public void print(){
			System.out.printf("%s\t%.2f%n", period, 3.6 * distance / period.time());
		}
	}

	public static void main(String[] args){
		int l = args.length > 0 ? Integer.parseInt(args[0]) : 0;
		List<Interval> store = new ArrayList<>();
		store.add(new Interval(8, 20));
		store.add(new Interval(7, 31));
		store.add(new Interval(4, 52));
		store.add(new Interval(5, 23));
		store.add(new Interval(6, 14));
		store.add(new Interval(3, 45));
		store.stream()
		     .filter(i -> i.time() > l)
		     .sorted((i, j) -> i.seconds() - j.seconds())
		     .map(Journey::new) //(i -> new Journey(i))
		     .forEach(Journey::print);
		Interval sum = store.stream()
				    .filter(i -> i.time() > l)
				    .reduce(new Interval(0, 0), Interval::add);
		System.out.printf("Total Interval = %s%n", sum);				
	}
}

