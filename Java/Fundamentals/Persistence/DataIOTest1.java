import java.io.*;

class DataIOTest1{

	public static void main(String[] args) throws Exception{
		if(args.length > 2){
			float price = Float.parseFloat(args[0]);
			short stock = Short.parseShort(args[1]);
			String name = args[2].toUpperCase();
			DataOutputStream dout = new DataOutputStream(
				new FileOutputStream("product.dat"));
			dout.writeFloat(price);
			dout.writeShort(stock);
			dout.writeUTF(name);
			dout.close();
		}else{
			DataInputStream din = new DataInputStream(
				new FileInputStream("product.dat"));
			float price = din.readFloat();
			short stock = din.readShort();
			String name = din.readUTF();
			din.close();
			System.out.printf("%s %s %s%n", price, stock, name);
		}
	}
}


