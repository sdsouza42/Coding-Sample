using System;

class Interval
{
	private int time;
	
	//property
	public int Time
	{
		get
		{
			return time;
		}

		set
		{
			time = value;
		}
	}

	//indexer - default parameterized (Item) property 
	public int this[int index]
	{
		get
		{
			return index == 0 ? (time % 60) : (time / 60);
		}
	}

	public void Print()
	{
		Console.WriteLine("{0}:{1:00}", time / 60, time % 60);
	}
	
}

static class Program
{
	private static float GetSpeed(float distance, Interval duration)
	{
		return 3.6f * distance / duration.Time; //duration.get_Time()
	}

	public static void Main()
	{
		Interval jack = new Interval();
		jack.Time = 125; //jack.set_Time(125)
		Console.Write("Jack's Interval = ");
		jack.Print();
		Console.WriteLine("Jack's Speed = {0}", GetSpeed(500, jack));

		Interval john = new Interval();
		john.Time = 200;
		Console.Write("John's Interval = ");
		Console.WriteLine("{0} minutes and {1} seconds.", john[1], john[0]); //john.get_Item(1)
		Console.WriteLine("John's Speed = {0}", GetSpeed(500, john));

	}
}
