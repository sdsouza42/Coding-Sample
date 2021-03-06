package model;

import java.util.*;
import java.sql.*;
import javax.sql.*;
import javax.naming.*;

public class RegisterBean implements java.io.Serializable{

	public String registered(String custID,String firstName, String lastName, String email, int phone, String company,String pwd){
		try{
			Context naming = new InitialContext();
			DataSource ds = (DataSource)naming.lookup("jdbc/Icecreamora");
			Connection con = ds.getConnection();
			con.setAutoCommit(false);
			try{
				
				PreparedStatement ps=con.prepareStatement("insert into JCUSTOMERS values(?,?,?,?,?,?,?)");
				ps.setString(1,custID);
				ps.setString(2,firstName);  
				ps.setString(3,lastName);  
				ps.setString(4,email);
				ps.setInt(5,phone);
				ps.setString(6,company);
				ps.setString(7,pwd);
				ps.executeUpdate();
				con.commit();
				return email;
				
			}catch(SQLException e){
				con.rollback();
				throw e;
			}finally{
				con.close();
			}
		}catch(Exception e){
			throw new RuntimeException(e);
		}	
	}
}


