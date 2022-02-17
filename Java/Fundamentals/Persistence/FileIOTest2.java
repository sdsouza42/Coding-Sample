import java.io.*;

class FileIOTest2{

	public static void main(String[] args) throws Exception{
		RandomAccessFile file = new RandomAccessFile(args[0], "rw");
		int n = (int)file.length();
		byte[] buffer = new byte[n];
		file.read(buffer);
		for(int i = 0, j = n - 1; i < j; ++i, j--){
			byte ib = buffer[i];
			byte jb = buffer[j];
			buffer[i] = jb;
			buffer[j] = ib;
		}
		file.seek(0);
		file.write(buffer);
		file.close();
	}
}

