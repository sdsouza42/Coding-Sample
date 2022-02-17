import java.io.*;
import java.net.*;
import java.util.*;

class TCPClientTest{

	public static void main(String[] args) throws Exception{
		String host = args.length > 0 ? args[0] : "localhost";
		Scanner input = new Scanner(System.in);
		Socket client = new Socket(host, 2055);
		BufferedReader br = new BufferedReader(
			new InputStreamReader(client.getInputStream()));
		PrintWriter pw = new PrintWriter(
			new OutputStreamWriter(client.getOutputStream()));
		System.out.println(br.readLine());
		System.out.print("SYMBOL: ");
		String symbol = input.next();
		pw.println(symbol);
		pw.flush();
		System.out.printf("RESULT: %s%n", br.readLine());
		pw.close();
		br.close();
		client.close();

	}
}

