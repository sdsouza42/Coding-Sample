package basicwebapp;

import java.io.*;
import java.util.*;
import javax.servlet.*;

public class GreeterServlet implements Servlet{

	private ServletConfig config;
	private String greet;

	public void init(ServletConfig cfg) throws ServletException{
		config = cfg;
		greet = cfg.getInitParameter("greet");
		if(greet == null)
			greet = "Welcome";
	}

	public void service(ServletRequest request, ServletResponse response) throws IOException, ServletException{
		String name = request.getParameter("visitor");
		if(name == null) name = "";
		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		out.println("<html>");
		out.println("<head><title>BasicWebApp</title></head>");
		out.println("<body>");
		out.printf("<h1>%s Visitor %s</h1>%n", greet, name);
		out.printf("<b>Time on server: </b>%s%n", new Date());
		out.println("</body>");
		out.println("</html>");
	}

	public ServletConfig getServletConfig(){
		return config;
	}

	public String getServletInfo(){
		return "basicwebapp.GreeterServlet";
	}

	public void destroy(){}
}

