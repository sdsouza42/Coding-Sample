package basicwebapp;

import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;

@WebServlet({"/state"})
public class StateServlet extends HttpServlet{

	@Override
	public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException{
		String name = request.getParameter("visitor");
		if(name.length() == 0){
			response.sendRedirect("wc");
			return;
		}
		HttpSession session = request.getSession(true);
		Integer m = (Integer)session.getAttribute(name);
		if(m == null) m = 1;
		session.setAttribute(name, m + 1);
		ServletContext application = getServletContext();
		Integer n;
		synchronized(application){
			n = (Integer)application.getAttribute("greetings");
			if(n == null) n = 1;
			application.setAttribute("greetings", n + 1);
		}
		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		out.println("<html>");
		out.println("<head><title>BasicWebApp</title></head>");
		out.println("<body>");
		out.printf("<h1>Hello %s</h1>%n", name);
		out.printf("<b>Number of greetings: </b>%d / %d%n", m, n);
		out.println("</body>");
		out.println("</html>");
	}
}

