import java.io.*;
import java.net.*;
import java.util.*;

class TCPServerTest2{

	public static void main(String[] args) throws Exception{
		ServerSocket listener = new ServerSocket(2055);
		for(int i = 0; i < 3; ++i){
			Thread child = new Thread(new Runnable(){
				public void run(){
					try{
						service(listener);
					}catch(IOException e){}
				}
			});
			child.start();
		}
	}

	private static void service(ServerSocket server) throws IOException{
		String[] symbols = {"APPL", "GOGL", "INTC", "MSFT", "ORCL"};
		Random rdm = new Random();
		for(;;){
			Socket client = server.accept();
			client.setSoTimeout(20000);
			InputStream in = client.getInputStream();
			OutputStream out = client.getOutputStream();
			BufferedReader br = new BufferedReader(
				new InputStreamReader(in));
			PrintWriter pw = new PrintWriter(
				new OutputStreamWriter(out), true);
			try{
				pw.println("Welcome to stock-exchange server");
				String symbol = br.readLine();
				int i = Arrays.binarySearch(symbols, symbol);
				if(i >= 0)
					pw.printf("Price is %.2f%n", 0.01 * (rdm.nextInt(9000) + 1000));
				else
					pw.println("Price not available");
			}catch(Exception e){}
			pw.close();
			br.close();
			client.close();
		}
	}
}

