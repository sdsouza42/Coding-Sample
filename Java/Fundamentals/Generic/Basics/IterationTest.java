import java.util.*;

class IterationTest{

	static class SimpleStack<V> implements Iterable<V>{

		private Node top;

		private class Node{
			V value;
			Node previous;

			Node(V val){
				value = val;
				previous = top;
			}
		}

		public void push(V value){
			top = new Node(value);
		}

		public V pop(){
			V result = top.value;
			top = top.previous;
			return result;
		}

		public boolean empty(){
			return top == null;
		}

		public Iterator<V> iterator(){
			return new Iterator<V>(){
				private Node current = top;

				public boolean hasNext(){
					return current != null;
				}

				public V next(){
					Node node = current;
					current = current.previous;
					return node.value;
				}
			};
		}

	}

	public static void main(String[] args){
		//Interval[] store = {new Interval(7, 31), new Interval(4, 52), new Interval(5, 23), new Interval(6, 14), new Interval(3, 45)};
		SimpleStack<Interval> store = new SimpleStack<>();
		store.push(new Interval(7, 31));
		store.push(new Interval(4, 52));
		store.push(new Interval(5, 23));
		store.push(new Interval(6, 14));
		store.push(new Interval(3, 45));
		for(Interval i : store)
			System.out.println(i);

	}
}

