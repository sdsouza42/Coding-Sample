import java.io.*;
import java.net.*;
import java.util.*;

class URLTest{
	
	public static void main(String[] args) throws Exception{
		String host = args.length > 0 ? args[0] : "localhost";
		Scanner input = new Scanner(System.in);
		System.out.print("SYMBOL: ");
		String symbol = input.next();
		String site = String.format("http://%s/stock.php?symbol=%s", host, symbol);
		URL url = new URL(site);
		InputStream in = url.openStream();
		BufferedReader br = new BufferedReader(
			new InputStreamReader(in));
		System.out.printf("RESULT: %s%n", br.readLine());
		br.close();
	}
}

