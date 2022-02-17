import java.util.*;

class HashMapTest{

	public static void main(String[] args){
		Map<String, Interval> store = new HashMap<>();
		store.put("monday", new Interval(7, 31));
		store.put("tuesday", new Interval(4, 52));
		store.put("wednesday", new Interval(5, 23));
		store.put("thursday", new Interval(6, 14));
		store.put("friday", new Interval(3, 45));
		store.put("monday", new Interval(8, 21));
		for(Map.Entry<String, Interval> pair : store.entrySet())
			System.out.printf("%s => %s%n", pair.getKey(), pair.getValue());
		Scanner input = new Scanner(System.in);
		System.out.print("Key: ");
		String key = input.next();
		Interval val = store.get(key);
		if(val != null)
			System.out.printf("Value = %s%n", val);
		else
			System.out.println("No such key!");
	}
}

