partial class Interval
{
	private int min;
	private int sec;

	partial void OnInit(); //partial method - maybe defined by other parts of this class

	public Interval(int m, int s)
	{
		min = m + s / 60;
		sec = s % 60;
		OnInit(); //will be removed if other part of this class does not define OnInit
	}

	public int Minutes
	{
		get {return min;}
	}

	public int Seconds
	{
		get {return sec;}
	}

	public int Time
	{
		get {return 60 * min + sec;}
	}

	public override string ToString()
	{
		if(sec < 10)
			return min + ":0" + sec;
		return min + ":" + sec;
	}

	public override int GetHashCode()
	{
		return 1000 * (60 * min + sec);
	}

	public override bool Equals(object other)
	{
		if(other is Interval)
		{
			Interval that = (Interval)other;
			return (this.min == that.min) && (this.sec == that.sec);			
		}

		return false;
	}
}
