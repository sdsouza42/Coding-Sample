package hr;

import java.io.*;

public class Employee implements Externalizable{

	private String code;
	private String password;
	private int experience;
	private double salary;

	public final String getCode(){
		return code;
	}

	public final void setCode(String value){
		code = value;
	}
	
	public final String getPassword(){
		return password;
	}

	public final void setPassword(String value){
		password = value;
	}

	public final int getExperience(){
		return experience;
	}

	public final void setExperience(int value){
		experience = value;
	}

	public final double getSalary(){
		return salary;
	}

	public final void setSalary(double value){
		salary = value;
	}

	@Override
	public String toString(){
		return String.format("%s\t%d\t%.2f\t%s", code, experience, salary, 
			password);
	}

	public void writeExternal(ObjectOutput out) throws IOException{
		out.writeUTF(code);
		out.writeInt(experience);
		out.writeDouble(salary);
		byte[] data = password.getBytes();
		for(int i = 0; i < data.length; ++i)
			data[i] = (byte)(data[i] ^ '#');
		out.writeInt(data.length);
		out.write(data);
	}
	
	public void readExternal(ObjectInput in) throws IOException{
		code = in.readUTF();
		experience = in.readInt();
		salary = in.readDouble();
		int n = in.readInt();
		byte[] data = new byte[n];
		in.read(data);
		for(int i = 0; i < data.length; ++i)
			data[i] = (byte)(data[i] ^ '#');
		password = new String(data);
	}
}




















