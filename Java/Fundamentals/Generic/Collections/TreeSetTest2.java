import java.util.*;

class TreeSetTest2{

	public static void main(String[] args){
		/*
		Set<Interval> store = new TreeSet<>(new Comparator<Interval>(){
			public int compare(Interval x, Interval y){
				return x.seconds() - y.seconds();
			}
		});
		*/
		Set<Interval> store = new TreeSet<>((x, y) -> x.seconds() - y.seconds());
		store.add(new Interval(7, 31));
		store.add(new Interval(4, 52));
		store.add(new Interval(5, 23));
		store.add(new Interval(6, 14));
		store.add(new Interval(3, 45));
		store.add(new Interval(2, 105));
		for(Interval i : store)
			System.out.println(i);
	}
}

