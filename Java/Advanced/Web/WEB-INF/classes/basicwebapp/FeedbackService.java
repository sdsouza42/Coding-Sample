package basicwebapp;

import java.util.*;
import javax.ws.rs.*;
import javax.ws.rs.core.*;

@Path("/feedbacks")
public class FeedbackService{

	private static List<FeedbackResource> store = new ArrayList<>();

	static{
		store.add(new FeedbackResource("Tester", "Everything is working fine."));
	}

	@GET
	@Path("/{id}")
	@Produces(MediaType.APPLICATION_JSON)
	public FeedbackResource readFeedback(@PathParam("id") String name){
		FeedbackResource feedback = findFirst(name);
		if(feedback == null)
			throw new WebApplicationException(Response.Status.NOT_FOUND);
		return feedback;
	}

	@POST
	@Consumes(MediaType.APPLICATION_JSON)
	public String writeFeedback(FeedbackResource resource){
		FeedbackResource feedback = findFirst(resource.name);
		String result;
		if(feedback == null){
			store.add(resource);
			result = "Feedback Accepted";
		}else{
			feedback.comment = resource.comment;
			result = "Feedback Updated";
		}
		return result;
	}

	private static FeedbackResource findFirst(String id){
		for(FeedbackResource entry : store){
			if(entry.name.equals(id))
				return entry;
		}
		return null;
	}

}

