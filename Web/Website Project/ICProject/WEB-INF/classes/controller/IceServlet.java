package controller;

import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;
@WebServlet({"/home", "/login","/register", "/order", "/logout"})
public class IceServlet extends HttpServlet{
	@Override
	public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException{

	String path = request.getServletPath();
		String view = "default";
		if(path.equals("/home"))
			view = processGetHome(request);
		else if(path.equals("/login"))
			view = processGetLogin(request);
		else if(path.equals("/register"))
			view = processGetRegister(request);
	RequestDispatcher rd = request.getRequestDispatcher(view);
		rd.forward(request, response);
	}


	@Override
	public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException{
		String path = request.getServletPath();
		String view = "default";
		if(path.equals("/login"))
			view = processPostLogin(request);
		else if(path.equals("/register"))
			view = processPostRegister(request);
		else if(path.equals("/order"))
			view = processPostOrder(request);
		RequestDispatcher rd = request.getRequestDispatcher(view);
		rd.forward(request, response);
		}

	private String processGetHome(HttpServletRequest request) throws ServletException{
		ServletContext application = getServletContext();
			//application.setAttribute("product", new model.ProductBean());
		return "/view/customer.jspx";
	}

	private String processGetLogin(HttpServletRequest request) throws ServletException{
		return "/view/customer.jspx";
	}

	private String processPostLogin(HttpServletRequest request) throws ServletException{
		HttpSession session = request.getSession(true);
		model.CustomerBean cb = (model.CustomerBean)session.getAttribute("icecream");
		if(cb == null){
			cb = new model.CustomerBean();
			session.setAttribute("icecream", cb);
		}
		String custId = request.getParameter("custId");
		String pwd = request.getParameter("pwd");
		if(cb.authenticate(custId, pwd))
			return "/view/order.jspx";
		request.setAttribute("failed", true);
		return "/view/customer.jspx";
		}

	private String processGetRegister(HttpServletRequest request) throws ServletException{
		return "/view/register.jsp";
	}
/*
	private String processPostRegister(HttpServletRequest request) throws ServletException{
		HttpSession session = request.getSession(true);
		model.RegisterBean rb = (model.RegisterBean)session.getAttribute("register");
		if(rb == null){
			rb = new model.RegisterBean();
			session.setAttribute("Register", rb);
			return "/view/register.jsp";
		}
		
		return "/view/login.jsp";
		}
*/
	private String processPostRegister(HttpServletRequest request) throws ServletException{
		HttpSession session = request.getSession(true);
		model.RegisterBean rb = (model.RegisterBean)session.getAttribute("icecream");
		if(rb == null)
			return "/view/index.jsp";
		String fname  = request.getParameter("fname");
		String lname  = request.getParameter("lname");
		String email  = request.getParameter("email");
		int phone  = Integer.parseInt(request.getParameter("phone"));
		String cname  = request.getParameter("cname");
		String uname  = request.getParameter("uname");
		String pwd  = request.getParameter("pwd");
		int custid = rb.Registered(fname,lname,email,phone,cname,uname,pwd);
		return "/view/customer.jspx";

	}
	
	private String processPostOrder(HttpServletRequest request) throws ServletException{
		HttpSession session = request.getSession(true);
		model.CustomerBean cb = (model.CustomerBean)session.getAttribute("icecream");
		if(cb == null)
			return "/view/customer.jspx";
		int productNo = Integer.parseInt(request.getParameter("productNo"));
		int quantity = Integer.parseInt(request.getParameter("quantity"));
		int orderNo = cb.placeOrder(productNo, quantity);
		request.setAttribute("orderNo", orderNo);
		return "/view/order.jspx";
	}
}









