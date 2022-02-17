class Interval{

	private int min;
	private int sec;

	public Interval(int m, int s){
		min = m + s / 60;
		sec = s % 60;
	}

	public int minutes(){
		return min;
	}

	public int seconds(){
		return sec;
	}

	public int time(){
		return 60 * min + sec;
	}

	public Interval add(Interval other){
		return new Interval(min + other.min, sec + other.sec);
	}

	public String toString(){
		if(sec < 10)
			return min + ":0" + sec;
		return min + ":" + sec;
	}

	public int hashCode(){
		return 1000 * time();
	}

	public boolean equals(Object other){
		if(other instanceof Interval){
			Interval that = (Interval)other;
			return (this.min == that.min) && (this.sec == that.sec);
		}
		return false;
	}
}

