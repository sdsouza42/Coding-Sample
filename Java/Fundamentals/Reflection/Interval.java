class Interval{

	private int minute;
	private int second;

	public Interval(int m, int s){
		minute = m + s / 60;
		second = s % 60;
	}

	public int minutes(){
		return minute;
	}

	public int seconds(){
		return second;
	}

	public int time(){
		return 60 * minute + second;
	}

	public Interval add(Interval other){
		return new Interval(minute + other.minute, second + other.second);
	}

	public String toString(){
		if(second < 10)
			return minute + ":0" + second;
		return minute + ":" + second;
	}

	public int hashCode(){
		return 1000 * time();
	}

	public boolean equals(Object other){
		if(other instanceof Interval){
			Interval that = (Interval)other;
			return (this.minute == that.minute) && (this.second == that.second);
		}
		return false;
	}
}

