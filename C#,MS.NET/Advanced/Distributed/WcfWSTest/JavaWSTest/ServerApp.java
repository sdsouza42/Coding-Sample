import survey.*;
import javax.xml.ws.*;

class ServerApp{

	public static void main(String[] args) throws Exception{
		System.setErr(new java.io.PrintStream("server.log"));
		Endpoint.publish("http://localhost:8056/survey/feedback", new FeedbackWS());
	}
}


