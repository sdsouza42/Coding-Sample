import java.io.*;

class FileIOTest1{

	private static void encode(InputStream source, OutputStream target) throws IOException{
		byte[] buffer = new byte[80];
		while(source.available() > 0){
			int n = source.read(buffer, 0, 80);
			for(int i = 0; i < n; ++i)
				buffer[i] = (byte)(buffer[i] ^ '#');
			target.write(buffer, 0, n);
		}
	}

	public static void main(String[] args) throws Exception{
		FileInputStream fin = new FileInputStream(args[0]);
		System.out.printf("Opened %s for reading%n", args[0]);
		FileOutputStream fout = new FileOutputStream(args[1]);
		System.out.printf("Opened %s for writing%n", args[1]);
		encode(fin, fout);
		fout.close();
		fin.close();
	}
}

