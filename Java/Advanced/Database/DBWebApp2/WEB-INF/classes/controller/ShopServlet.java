package controller;

import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;

@WebServlet({"/home", "/login", "/order", "/logout"})
public class ShopServlet extends HttpServlet{

	@Override
	public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException{
		String path = request.getServletPath();
		String view = "default";
		if(path.equals("/home"))
			view = processGetHome(request);
		else if(path.equals("/login"))
			view = processGetLogin(request);
		else if(path.equals("/logout"))
			view = processGetLogout(request);
		RequestDispatcher rd = request.getRequestDispatcher(view);
		rd.forward(request, response);
	}
	
	@Override
	public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException{
		String path = request.getServletPath();
		String view = "default";
		if(path.equals("/login"))
			view = processPostLogin(request);
		else if(path.equals("/order"))
			view = processPostOrder(request);
		RequestDispatcher rd = request.getRequestDispatcher(view);
		rd.forward(request, response);
	}

	private String processGetHome(HttpServletRequest request) throws ServletException{
		ServletContext application = getServletContext();
		application.setAttribute("product", new model.ProductBean());
		return "/view/product.jspx";
	}

	private String processGetLogin(HttpServletRequest request) throws ServletException{
		return "/view/customer.jspx";
	}

	private String processPostLogin(HttpServletRequest request) throws ServletException{
		HttpSession session = request.getSession(true);
		model.CustomerBean cb = (model.CustomerBean)session.getAttribute("customer");
		if(cb == null){
			cb = new model.CustomerBean();
			session.setAttribute("customer", cb);
		}
		String custId = request.getParameter("custId");
		String pwd = request.getParameter("pwd");
		if(cb.authenticate(custId, pwd))
			return "/view/order.jspx";
		request.setAttribute("failed", true);
		return "/view/customer.jspx";
	}
	
	private String processPostOrder(HttpServletRequest request) throws ServletException{
		HttpSession session = request.getSession(true);
		model.CustomerBean cb = (model.CustomerBean)session.getAttribute("customer");
		if(cb == null)
			return "/view/customer.jspx";
		int productNo = Integer.parseInt(request.getParameter("productNo"));
		int quantity = Integer.parseInt(request.getParameter("quantity"));
		int orderNo = cb.placeOrder(productNo, quantity);
		request.setAttribute("orderNo", orderNo);
		return "/view/order.jspx";
	}

	private String processGetLogout(HttpServletRequest request) throws ServletException{
		HttpSession session = request.getSession(false);
		if(session != null)
			session.invalidate();
		return "/view/product.jspx";
	}
}
