package hr;

import javax.xml.bind.annotation.*;

public class Employee{

	private String code;
	private String password;
	private int experience;
	private double salary;

	@XmlAttribute
	public final String getCode(){
		return code;
	}

	public final void setCode(String value){
		code = value;
	}
	
	@XmlTransient
	public final String getPassword(){
		return password;
	}

	public final void setPassword(String value){
		password = value;
	}

	public final byte[] getData(){
		byte[] data = password.getBytes();
		for(int i = 0; i < data.length; ++i)
			data[i] = (byte)(data[i] ^ '#');
		return data;
	}

	public final void setData(byte[] data){
		for(int i = 0; i < data.length; ++i)
			data[i] = (byte)(data[i] ^ '#');
		password = new String(data);
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
	
}




















