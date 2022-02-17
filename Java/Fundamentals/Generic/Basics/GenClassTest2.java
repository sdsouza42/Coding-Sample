class GenClassTest2{

	interface Stack<V>{
		void push(V value);
		V pop();
		boolean empty();
	}

	static class SimpleStack<V> implements Stack<V>{

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

		public void copy(Stack<? super V> target){
			for(Node n = top; n != null; n = n.previous)
				target.push(n.value);
		}

	}

	static class FiniteStack<V> implements Stack<V>{

		private V[] values;
		private int count;

		FiniteStack(V[] store){
			values = store;
		}

		public void push(V value){
			values[count++] = value;
		}

		public V pop(){
			return values[--count];
		}

		public boolean empty(){
			return count == 0;
		}
	}

	private static void printStack(Stack<?> entries){
		for(int i = 0; !entries.empty(); ++i){
			if(i > 0) System.out.print(", ");
			System.out.print(entries.pop());
		}
		System.out.println();
	}

	public static void main(String[] args){
		SimpleStack<String> a = new SimpleStack<String>();
		a.push("Monday");
		a.push("Tuesday");
		a.push("Wednesday");
		a.push("Thursday");
		a.push("Friday");
		FiniteStack<String> b = new FiniteStack<>(new String[12]); 
		b.push("June");
		b.push("May");
		b.push("April");
		b.push("March");
		a.copy(b);
		SimpleStack<Interval> c = new SimpleStack<>();
		c.push(new Interval(7, 31));
		c.push(new Interval(4, 52));
		c.push(new Interval(5, 23));
		c.push(new Interval(6, 14));
		c.push(new Interval(3, 45));
		SimpleStack<Object> d = new SimpleStack<>();
		d.push("Saturday");
		d.push(new Interval(2, 40));
		d.push(4.56);
		c.copy(d);
		printStack(a);
		printStack(b);
		printStack(c);
		printStack(d);
	}
}

