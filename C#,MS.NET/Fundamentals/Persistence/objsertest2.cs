using HR;
using System;

[Serializable]
public class Office
{
	public Employee Manager {get; set;}

	public void Show()
	{
		Console.WriteLine("Manager's password is {0} in AppDomain<{1}>", Manager.Password, AppDomain.CurrentDomain.Id);
	}
}

static class Program
{
	public static void Main()
	{
		Office myoffice = new Office();
		myoffice.Manager = new Employee{Password="x1y2z3"};
		myoffice.Show();
		
		AppDomain dom = AppDomain.CreateDomain("second");
		dom.DoCallBack(myoffice.Show); //marshal myoffice (by value) to second app-domain and call its Show method
		AppDomain.Unload(dom);	
	}
}
