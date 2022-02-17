using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

static class Program
{
	private static void RunServer()
	{
		Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		EndPoint local = new IPEndPoint(IPAddress.Any, 2055);
		server.Bind(local);
		server.Listen(10);
		
		for(;;)
		{
			Socket client = server.Accept();

			byte[] buffer = new byte[80];
			int n = client.Receive(buffer, 0, buffer.Length, SocketFlags.None);
			for(int i = 0; i < n; ++i)
				buffer[i] = (byte)(buffer[i] ^ '#');
			client.Send(buffer, 0, buffer.Length, SocketFlags.None);

			client.Close();
		}
		
	}

	private static void RunClient(string host, string text)
	{
		IPHostEntry entry = Dns.GetHostEntry(host);
		IPAddress address = Array.Find(entry.AddressList, a => a.AddressFamily == AddressFamily.InterNetwork);

		Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		EndPoint remote = new IPEndPoint(address, 2055);
		client.Connect(remote);

		byte[] request = Encoding.ASCII.GetBytes(text);
		client.Send(request, 0, request.Length, SocketFlags.None);
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
