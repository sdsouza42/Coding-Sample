import java.util.*;
import java.lang.reflect.*;
import java.net.*;

class ClassLoaderTest{

	public static void main(String[] args) throws Exception{
		Scanner input = new Scanner(System.in);
		URL[] codebase = {new URL("file:./CMD-INF/")};
		for(;;){
			System.out.print("CMD>>>");
			String cmd = input.next();
			if(cmd.equals("Quit")) break;
			try{
				Class<?> c = Class.forName("commands." + cmd, true, new URLClassLoader(codebase));
				Method m = c.getMethod("execute", String.class);
				m.invoke(null, "ClassLoaderTest");
			}catch(Exception e){
				System.out.printf("ERROR: %s%n", e);
			}
			System.out.println();
		}
	}
}

