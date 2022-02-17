using System;
using System.IO;

static class Program
{
	public static void Main(string[] args)
	{
		FileStream fs = new FileStream(args[0], FileMode.Open, FileAccess.ReadWrite);
		int n = (int)fs.Length;
		byte[] buffer = new byte[n];

		fs.Read(buffer, 0, n);
		Array.Reverse(buffer);
		fs.Position = 0;
		fs.Write(buffer, 0, n);

		fs.Close();
	}
}
