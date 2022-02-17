import java.net.*;

class UDPSubTest{

	public static void main(String[] args) throws Exception{
		InetAddress group = InetAddress.getByName("230.0.0.1");
		MulticastSocket subscriber = new MulticastSocket(3055);
		subscriber.joinGroup(group);
		DatagramPacket packet = new DatagramPacket(new byte[65507], 65507);
		for(int i = 0; i < 5; ++i){
			subscriber.receive(packet);
			String msg = new String(packet.getData(), 0, packet.getLength());
			System.out.println(msg);
		}
		subscriber.leaveGroup(group);
		subscriber.close();
	}
}

