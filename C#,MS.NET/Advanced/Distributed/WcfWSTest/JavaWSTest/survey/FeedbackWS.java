package survey;

import java.util.*;
import javax.jws.*;

@WebService(name="Feedback", serviceName="FeedbackService", portName="FeedbackSoap") 
public class FeedbackWS{

	private static List<FeedbackDetail> store = new ArrayList<>();

	static{
		store.add(new FeedbackDetail("Greeter", "Welcome to Java Web Service"));
	}

	private static FeedbackDetail find(String id){
		for(FeedbackDetail entry : store){
			if(entry.name.equals(id))
				return entry;
		}
		return null;
	}

	@WebMethod(operationName="ReadFeedback")
	public FeedbackDetail review(String name){
		FeedbackDetail detail = find(name);
		if(detail == null)
			throw new IllegalArgumentException("Not Found!");
		return detail;
	}

	@WebMethod(operationName="WriteFeedback") 
	public String submit(FeedbackDetail feedback){
		FeedbackDetail detail = find(feedback.name);
		String result;
		if(detail == null){
			store.add(feedback);
			result = "Accepted";
		}else{
			detail.text = feedback.text;
			result = "Modified";
		}
		return result;
	}
}











