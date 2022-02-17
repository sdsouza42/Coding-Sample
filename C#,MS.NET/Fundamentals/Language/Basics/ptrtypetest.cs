using System;

enum RoomType {Economy, Business, Executive, Deluxe}

//user defined value-type
struct HotelRoom
{
	public int Number;

	public RoomType Category;

	public bool Taken;

	public void Print()
	{
		Console.WriteLine("Room {0} is of {1} class and is currently {2}.", Number, Category, Taken ? "Occupied" : "Available");
	}	
}

static class Program
{
	private unsafe static void Take(HotelRoom* room)
	{
		if(room->Taken == false)
			room->Taken = true;
	}

	public unsafe static void Main()
	{
		HotelRoom myroom;
		myroom.Number = 503;
		myroom.Category = RoomType.Business;
		myroom.Taken = false;

		myroom.Print();
		Console.WriteLine($"Taking room {myroom.Number}...");
		Take(&myroom);
		myroom.Print();
	}
}
