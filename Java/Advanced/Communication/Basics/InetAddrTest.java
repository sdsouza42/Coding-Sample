import java.net.*;

class InetAddrTest{

	public static void main(String[] args){
		try{
			InetAddress addr = args.length > 0 ? InetAddress.getByName(args[0]) : InetAddress.getLocalHost();
			System.out.println(addr);
		}catch(Exception e){
			System.out.println("Cannot resolve host-name");
		}
	}
}

