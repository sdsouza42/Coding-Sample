import hr.*;
import java.io.*;

class ObjSerTest{

	public static void main(String[] args) throws Exception{
		if(args.length > 0){
			Department dept = new Department();
			dept.setTitle(args[0]);
			dept.addEmployee(5, 52000);
			dept.addEmployee(3, 32000);
			dept.addEmployee(2, 22000);
			dept.addEmployee(4, 42000);
			dept.addEmployee(6, 62000);
			ObjectOutputStream oout = new ObjectOutputStream(
				new FileOutputStream("dept.dat"));
			oout.writeObject(dept);
			oout.close();
		}else{
			ObjectInputStream oin = new ObjectInputStream(
				new FileInputStream("dept.dat"));
			Department dept = (Department)oin.readObject();
			oin.close();
			System.out.printf("Employees of %s department%n", dept.getTitle());
			for(Employee emp : dept.getEmployees())
				System.out.println(emp);

		}
	}
}


