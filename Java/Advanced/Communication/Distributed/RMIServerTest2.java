import java.rmi.*;
import javax.naming.*;

class RMIServerTest2{

	public static void main(String[] args) throws Exception{
		Context naming = new InitialContext();
		naming.rebind("cartFactory", new shopping.CartFactoryImpl());
	}
}

