using System;
using System.Text;
using System.Net;

static class Program
{
	public static void Main(string[] args)
	{
		WebClient client = new WebClient();
		string site = "http://khussain.met.edu/encode.asp";
		byte[] request = Encoding.ASCII.GetBytes(args[0]);
		byte[] response = client.UploadData(site, request);

		Console.WriteLine("RESPONSE: {0}", Encoding.ASCII.GetString(response));
	}
}
