class GenClassTest1{

	static class SimpleStack<V>{

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

	}

	public static void main(String[] args){
		SimpleStack<String> a = new SimpleStack<String>();
		a.push("Monday");
		a.push("Tuesday");
		a.push("Wednesday");
		a.push("Thursday");
		a.push("Friday");
		SimpleStack<String> b = new SimpleStack<>(); //SimpleStack<String>()
		b.push("June");
		b.push("May");
		b.push("April");
		b.push("March");
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
		while(!a.empty())
			System.out.println(a.pop());
		System.out.println();
		while(!b.empty())
			System.out.println(b.pop());
		System.out.println();
		while(!c.empty())
			System.out.println(c.pop());
		System.out.println();
		while(!d.empty())
			System.out.println(d.pop());

	}
}

