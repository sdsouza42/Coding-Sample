package survey;

import javax.xml.bind.annotation.*;

@XmlType(name="FeedbackInfo")
public class FeedbackDetail{

	String name;
	String text;

	public FeedbackDetail(String from, String comment){
		name = from;
		text = comment;
	}

	public FeedbackDetail(){}

	@XmlElement(name="From")
	public final String getName(){
		return name;
	}

	public final void setName(String value){
		name = value;
	}

	@XmlElement(name="Comment")
	public final String getText(){
		return text;
	}

	public final void setText(String value){
		text = value;
	}
}










