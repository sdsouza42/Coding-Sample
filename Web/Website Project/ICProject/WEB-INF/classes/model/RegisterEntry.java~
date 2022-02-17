package model;

import java.sql.*;

public class RegisterEntry{
	
	private String custID;
	private String firstName;
	private String lastName;
	private String email;
	private int 	phone;
	private String company;
	private String	pwd;
	

	RegisterEntry(ResultSet rs) throws SQLException{
		custID = rs.getString("custID");
		firstName = rs.getString("fname");
		lastName = rs.getString("lname");
		email = rs.getString("email");
		phone = rs.getInt("phone");
		company = rs.getString("cname");
		pwd = rs.getString("pwd");
		
	}

	
	public final String custID(){
		return custID;
	}

	public final String firstName(){
		return firstName;
	}

	public final String lastName(){
		return lastName;
	}

	public final String email(){
		return email;
	}
	
	public final int phone(){
		return phone;
	}

	public final String company(){
		return company;
	}
	
	
	public final String pwd(){
		return pwd;
	}
}

