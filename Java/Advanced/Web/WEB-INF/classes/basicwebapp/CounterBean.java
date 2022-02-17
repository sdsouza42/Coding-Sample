package basicwebapp;

public class CounterBean implements java.io.Serializable{

	private int step;
	private long count;

	public CounterBean(){
		step = 1;
		count = 0;
	}

	public final int getStep(){
		return step;
	}

	public final void setStep(int value){
		step = value;
	}

	public synchronized long getNextCount(){
		return count += step;
	}

}

