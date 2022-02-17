using System;
using System.Text;
using System.IO.Pipes;

static class Program
{
	private static void RunServer()
	{
		using(NamedPipeServerStream server = new NamedPipeServerStream("encpipe"))
		{
			for(;;)
			{
				server.WaitForConnection();

				byte[] buffer = new byte[80];
				int n = server.Read(buffer, 0, buffer.Length);
				for(int i = 0; i < n; ++i)
					buffer[i] = (byte)(buffer[i] ^ '#');
				server.Write(buffer, 0, n);

				server.Disconnect();
			}
		}
	}

	private static void RunClient(string text)
	{
		using(NamedPipeClientStream client = new NamedPipeClientStream(".", "encpipe"))
		{
			client.Connect();

			byte[] request = Encoding.ASCII.GetBytes(text);
			client.Write(request, 0, request.Length);
			byte[] response = new byte[80];
			int n = client.Read(response, 0, response.Length);
			Console.WriteLine("RESPONSE: {0}", Encoding.ASCII.GetString(response, 0, n));
		}
	}

	public static void Main(string[] args)
	{
		if(args.Length == 0)
			RunServer();
		else
			RunClient(args[0]);
	}
}
