using System;

enum RoomType {Economy, Business, Executive, Deluxe}

//user defined reference-type
class HotelRoom
{
	public int Number;

	public RoomType Category = RoomType.Business; //field initializer 

	public bool Taken;

	public void Print()
	{
		Console.WriteLine("Room {0} is of {1} class and is currently {2}.", Number, Category, Taken ? "Occupied" : "Available");
	}	
}

static class Program
{
	private static void Take(HotelRoom room)
	{
		if(room != null && room.Taken == false)
			room.Taken = true;
	}

	public static void Main()
	{
		HotelRoom myroom = new HotelRoom();
		myroom.Number = 503;
		myroom.Taken = false;

		myroom.Print();
		Console.WriteLine($"Taking room {myroom.Number}...");
		Take(myroom);
		myroom.Print();
	}
}
