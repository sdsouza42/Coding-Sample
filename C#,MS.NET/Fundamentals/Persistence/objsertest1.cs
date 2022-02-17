using HR;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

static class Program
{
	public static void Main(string[] args)
	{
		BinaryFormatter serializer = new BinaryFormatter();
	
		if(args.Length > 0)
		{
			Department dept = new Department();
			dept.Title = args[0];
			dept.AddEmployee(3, 32000);
			dept.AddEmployee(5, 54000);
			dept.AddEmployee(6, 65000);
			dept.AddEmployee(4, 43000);
			dept.AddEmployee(2, 21000);
	
			using(Stream output = File.Create("dept.dat"))
				serializer.Serialize(output, dept);
		}
		else
		{
			Department dept;
			using(Stream input = File.OpenRead("dept.dat"))
				dept = (Department)serializer.Deserialize(input);

			Console.WriteLine($"Employees of {dept.Title} department");
			foreach(Employee emp in dept.Employees)	
				Console.WriteLine(emp);
		}
	}
}
