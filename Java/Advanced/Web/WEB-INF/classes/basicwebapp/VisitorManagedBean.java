package basicwebapp;

import java.util.*;
import javax.faces.bean.*;

@ManagedBean(name="visitorManager")
@ViewScoped
public class VisitorManagedBean{

	private static List<Visitor> store = new ArrayList<>();

	static{
		store.add(new Visitor("Jack"));
		store.add(new Visitor("Jill"));
	}

	public Iterable<Visitor> getVisitors(){
		return store;
	}

	public String updateFor(String name){
		Visitor visitor = findFirst(name);
		if(visitor == null)
			store.add(new Visitor(name));
		else
			visitor.visit();
		return "facelettest";
	}

	private static Visitor findFirst(String id){
		for(Visitor entry : store){
			if(entry.name.equals(id))
				return entry;
		}
		return null;
	}
}

