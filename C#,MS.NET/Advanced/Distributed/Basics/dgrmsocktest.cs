using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

static class Program
{
	private static void RunServer()
	{
		Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		EndPoint local = new IPEndPoint(IPAddress.Any, 2055);
		server.Bind(local);
		
		for(;;)
		{
			EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
			byte[] buffer = new byte[80];
			int n = server.ReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remote);
			for(int i = 0; i < n; ++i)
				buffer[i] = (byte)(buffer[i] ^ '#');
			server.SendTo(buffer, 0, buffer.Length, SocketFlags.None, remote);
		}
		
	}

	private static void RunClient(string host, string text)
	{
		IPHostEntry entry = Dns.GetHostEntry(host);
		IPAddress address = Array.Find(entry.AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);

		Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

		EndPoint remote = new IPEndPoint(address, 2055);
		byte[] request = Encoding.ASCII.GetBytes(text);
		client.SendTo(request, 0, request.Length, SocketFlags.None, remote);
		byte[] response = new byte[80];
		int n = client.Receive(response, 0, response.Length, SocketFlags.None);
		Console.WriteLine("RESPONSE: {0}", Encoding.ASCII.GetString(response, 0, n));

		client.Close();
	}

	public static void Main(string[] args)
	{
		if(args.Length == 0)
			RunServer();
		else
			RunClient(args[0], args[1]);
	}
}
