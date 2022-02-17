import survey.client.*;

class ClientApp{

	public static void main(String[] args) throws Exception{
		FeedbackService service = new FeedbackService();
		Feedback proxy = service.getFeedbackSoap();
		try{
			if(args.length == 1){
				FeedbackInfo info = proxy.readFeedback(args[0]);
				System.out.printf("Comment: %s%n", info.getComment());
			}else if(args.length == 2){
				FeedbackInfo info = new FeedbackInfo();
				info.setFrom(args[0]);
				info.setComment(args[1]);
				System.out.println(proxy.writeFeedback(info));
			}
		}catch(Exception e){
			System.out.println(e.getMessage());
		}
	}
}


