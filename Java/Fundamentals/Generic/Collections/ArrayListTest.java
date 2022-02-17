import java.util.*;

class ArrayListTest{

	public static void main(String[] args){
		List<Interval> store = new ArrayList<>();
		store.add(new Interval(7, 31));
		store.add(new Interval(4, 52));
		store.add(new Interval(5, 23));
		store.add(new Interval(6, 14));
		store.add(new Interval(3, 45));
		store.add(new Interval(2, 105));
		for(Interval i : store)
			System.out.println(i);
		System.out.printf("Third Interval = %s%n", store.get(2));
	}
}

