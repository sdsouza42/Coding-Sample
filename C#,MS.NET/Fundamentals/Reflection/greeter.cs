public interface IGreeter
{
	string Meet(string name, int age);

	string Leave(string name);
}

public class EnglishGreeter : IGreeter
{
	public string Meet(string name, int age)
	{
		if(age < 17)
			return "Hi " + name;

		return "Hello " + name;
	}

	public string Leave(string name)
	{
		return "Bye " + name;
	}

}
