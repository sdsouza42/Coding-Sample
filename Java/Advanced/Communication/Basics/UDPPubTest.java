import java.net.*;
import java.util.*;

class UDPPubTest{

	public static void main(String[] args) throws Exception{
		String[] symbols = {"APPL", "GOGL", "INTC", "MSFT", "ORCL"};
		Random rdm = new Random();
		InetAddress remote = InetAddress.getByName("230.0.0.1");
		DatagramSocket publisher = new DatagramSocket();
		for(;;){
			int i = rdm.nextInt(symbols.length);
			String msg = String.format("%s : %.2f", symbols[i], 0.01 * (rdm.nextInt(9000) + 1000));
			DatagramPacket packet = new DatagramPacket(msg.getBytes(), msg.length(), remote, 3055);
			publisher.send(packet);
			Thread.sleep(10000);
		}
	}
}

