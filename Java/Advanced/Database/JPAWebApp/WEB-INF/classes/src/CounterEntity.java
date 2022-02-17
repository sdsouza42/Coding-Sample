package edu.met.sales;

import javax.persistence.*;

@Entity
@Table(name="counters")
public class CounterEntity implements java.io.Serializable{

	@Id
	@Column(name="ctr_name")
	private String name;

	@Column(name="cur_val")
	private int currentValue;

	public String getName(){
		return name;
	}

	public int getNextValue(){
		return ++currentValue;
	}
}

