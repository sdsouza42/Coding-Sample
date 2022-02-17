using System;

class Customer
{
	//auto-property
	public string Name {get; set;}

	//auto-property with initializer
	public double Credit {get; set;} = 1000;
}

static class Program
{
	public static void Main()
	{	
		//object initializer
		Customer a = new Customer{Name="Jack", Credit=2000};
		Console.WriteLine("{0}'s credit is {1}", a.Name, a.Credit);

		//implicitly typed local (var=Customer)
		var b = new Customer{Name="Jill"};
		Console.WriteLine("{0}'s credit is {1}", b.Name, b.Credit);

		//anonymous type
		var c = new{Id=23, Score=67.0};
		Console.WriteLine("Score of student with Id {0} is {1}", c.Id, c.Score);

		//reusing anonymous type
		var d = new{Id=31, Score=44.0};
		Console.WriteLine("Score of student with Id {0} is {1}", d.Id, d.Score);

	}
}
