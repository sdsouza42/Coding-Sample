package basicwebapp;

import javax.xml.bind.annotation.*;

@XmlRootElement
public class FeedbackResource{

	String name;
	String comment;

	public FeedbackResource(){}

	FeedbackResource(String id, String text){
		name = id;
		comment = text;
	}

	@XmlElement(name="Name")
	public String getName(){
		return name;
	}

	public void setName(String value){
		name = value;
	}

	@XmlElement(name="Comment")
	public String getComment(){
		return comment;
	}

	public void setComment(String value){
		comment = value;
	}
}

