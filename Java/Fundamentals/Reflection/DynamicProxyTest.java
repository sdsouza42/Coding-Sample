import java.lang.reflect.*;

class EchoProxy{

	/*
	public static Greeter createFor(Greeter original){
		Class<?> c = original.getClass();
		return new Greeter(){
			public String meet(String name, int age){
				System.out.printf(">> Invoking %s method of %s%n", "meet", c);
				return original.meet(name, age);
			}
			
			public String leave(String name){
				System.out.printf(">> Invoking %s method of %s%n", "leave", c);
				return original.leave(name);
			}
		};
	}
	*/

	public static Object createFor(Object original){
		Class<?> c = original.getClass();
		InvocationHandler ih = new InvocationHandler(){		
			public Object invoke(Object proxy, Method method, Object[] arguments) throws Exception{
				System.out.printf(">> Invoking %s method of %s%n", method.getName(), c);
				return method.invoke(original, arguments);
			}
		};
		return Proxy.newProxyInstance(c.getClassLoader(), c.getInterfaces(), ih);
	}
}

class DynamicProxyTest{

	public static void main(String[] args){
		Greeter g = new EnglishGreeter();
		//Greeter gp = EchoProxy.createFor(g);
		Greeter gp = (Greeter)EchoProxy.createFor(g);
		System.out.println(gp.meet("Jack", 17));
		System.out.println(gp.leave("Jack"));
	}
}

