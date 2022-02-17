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

static unsafe class Program
{
	private static void Take(HotelRoom* room)
	{
		if(room->Taken == false)
			room->Taken = true;
	}

	public static void Main()
	{
		HotelRoom[] myfloor = new HotelRoom[4];
		for(int i = 0; i < 4; ++i)
		{
			myfloor[i].Number = 501 + i;
			myfloor[i].Category = RoomType.Business;
			myfloor[i].Taken = false;
		}

		myfloor[2].Print();
		Console.WriteLine($"Taking room {myfloor[2].Number}...");
		fixed(HotelRoom* pRoom = &myfloor[2])
		{
			Take(pRoom);
		}
		myfloor[2].Print();
	}
}
