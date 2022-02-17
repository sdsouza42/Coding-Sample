import javax.xml.ws.*;

class JWSServerTest{

	public static void main(String[] args) throws Exception{
		System.setErr(null); //disable logging on error stream
		Endpoint.publish("http://localhost:8055/shopping/shopkeeper", new shopping.ShopKeeperWS());
	}
}

