package shopping;

import java.util.*;

class Store{

	private static Random rdm = new Random();
	private static String[] items = {"apple", "mango", "orange", "peach", "pear"};

	public static int findItem(String item){
		return Arrays.binarySearch(items, item);
	}

	public static double priceOf(int id){
		String item = items[id];
		return 0.01 * (rdm.nextInt(1500) + 1000);
	}

	public static int stockOf(int id){
		String item = items[id];
		return 100 + rdm.nextInt(401);
	}
}

