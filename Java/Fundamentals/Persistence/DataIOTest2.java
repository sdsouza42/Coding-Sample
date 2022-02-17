import java.io.*;

class DataIOTest2{

	public static void main(String[] args) throws Exception{
		if(args.length > 2){
			float price = Float.parseFloat(args[0]);
			short stock = Short.parseShort(args[1]);
			String name = args[2].toUpperCase();
			PrintWriter pw = new PrintWriter(
				new OutputStreamWriter(
				new FileOutputStream("product.txt")));
			pw.println(price);
			pw.println(stock);
			pw.println(name);
			pw.close();
		}else{
			BufferedReader br = new BufferedReader(
				new InputStreamReader(
				new FileInputStream("product.txt")));
			float price = Float.parseFloat(br.readLine());
			short stock = Short.parseShort(br.readLine());
			String name = br.readLine();
			br.close();
			System.out.printf("%s %s %s%n", price, stock, name);
		}
	}
}


