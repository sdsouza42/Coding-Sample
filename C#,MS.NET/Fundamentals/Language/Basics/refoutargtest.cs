using System;

enum RoomType {Economy, Business, Executive, Deluxe}

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
	private static void Take(ref HotelRoom room)
	{
		if(room.Taken == false)
			room.Taken = true;
	}

	private static int count;

	private static bool OpenBusinessRoom(out HotelRoom room)
	{
		room.Number = 501 + count++;
		room.Category = RoomType.Business;
		room.Taken = false;

		return count < 10;
	}

	public static void Main()
	{
		HotelRoom myroom;
		if(OpenBusinessRoom(out myroom))
		{
			myroom.Print();
			Console.WriteLine($"Taking room {myroom.Number}...");
			Take(ref myroom);
			myroom.Print();
		}
	}
}
