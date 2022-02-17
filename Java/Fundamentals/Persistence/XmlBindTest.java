import hr.*;
import java.io.*;
import javax.xml.bind.*;

class XmlBindTest{

	public static void main(String[] args) throws Exception{
		JAXBContext context = JAXBContext.newInstance(Department.class);
		if(args.length > 0){
			Department dept = new Department();
			dept.setTitle(args[0]);
			dept.addEmployee(5, 52000);
			dept.addEmployee(3, 32000);
			dept.addEmployee(2, 22000);
			dept.addEmployee(4, 42000);
			dept.addEmployee(6, 62000);
			Marshaller m = context.createMarshaller();
			m.setProperty("jaxb.formatted.output", true);
			try(FileWriter fw = new FileWriter("dept.xml")){
				m.marshal(dept, fw);
			}
		}else{
			Unmarshaller u = context.createUnmarshaller();
			Department dept;
			try(FileReader fr = new FileReader("dept.xml")){
				dept = (Department)u.unmarshal(fr);
			}
			System.out.printf("Employees of %s department%n", dept.getTitle());
			for(Employee emp : dept.getEmployees())
				System.out.println(emp);
		}
	}
}


