using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HR
{
	[Serializable]
	public class Employee : ISerializable 
	{
		private string code;
		private string password;
		private int experience;
		private double salary;

		public Employee(){}

		public string Code
		{
			get {return code;}
			set {code = value;}
		}

		public string Password
		{
			get {return password;}
			set {password = value;}
		}

		public int Experience
		{
			get {return experience;}
			set {experience = value;}
		}

		public double Salary
		{
			get {return salary;}
			set {salary = value;}
		}

		public override string ToString()
		{
			return string.Format("{0}\t{1}\t{2}\t{3}", code, password, experience, salary);
		}

		//called during serialization
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_code", code);
			info.AddValue("_experience", experience);
			info.AddValue("_salary", salary);

			if(context.State == StreamingContextStates.CrossAppDomain)
			{
				char[] buffer = password.ToCharArray();
				Array.Reverse(buffer);
				string rpwd = new string(buffer);
				info.AddValue("_rpwd", rpwd);
			}
			else
			{
				byte[] data = Encoding.UTF8.GetBytes(password);
				for(int i = 0; i < data.Length; ++i)
					data[i] = (byte)(data[i] ^ '#');
				string eps = Convert.ToBase64String(data);
				info.AddValue("_data", eps); 
			}
		}

		//used for creating deserialized object
		private Employee(SerializationInfo info, StreamingContext context)
		{
			code = info.GetString("_code");
			experience = info.GetInt32("_experience");
			salary = info.GetDouble("_salary");

			if(context.State == StreamingContextStates.CrossAppDomain)
			{
				password = info.GetString("_rpwd");
				//TODO reverse password
			}
			else
			{
				String eps = info.GetString("_data");
				byte[] data = Convert.FromBase64String(eps);
				for(int i = 0; i < data.Length; ++i)
					data[i] = (byte)(data[i] ^ '#');
				password = Encoding.UTF8.GetString(data);
			}
		}
	
	}

	[Serializable]
	public class Department
	{
		private string title = null;
		private List<Employee> employees = new List<Employee>();

		public string Title
		{
			get {return title;}
			set {title = value;}
		}

		public List<Employee> Employees
		{
			get {return employees;}
			set {employees = value;}
		}

		public Employee AddEmployee(int exp, double sal){
			Employee emp = new Employee();
			int i = 501 + employees.Count;

			emp.Code = title.Substring(0, 3).ToUpper() + i;
			emp.Password = "PWD" + i;
			emp.Experience = exp;
			emp.Salary = sal;
			employees.Add(emp);

			return emp;
		}

	}

}

















