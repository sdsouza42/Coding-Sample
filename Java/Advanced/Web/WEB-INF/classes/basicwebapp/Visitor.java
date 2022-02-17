package basicwebapp;

import java.util.*;

public class Visitor{

	String name;
	int frequency;
	Date recent;

	public Visitor(String id){
		name = id;
		frequency = 1;
		recent = new Date();
	}

	public String getName(){
		return name;
	}

	public int getFrequency(){
		return frequency;
	}

	public Date getRecent(){
		return recent;
	}

	public void visit(){
		frequency += 1;
		recent = new Date();
	}
}

