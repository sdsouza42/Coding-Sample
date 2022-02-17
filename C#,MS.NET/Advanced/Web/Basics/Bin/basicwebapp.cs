using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace BasicWebApp
{
	public class PageModule : IHttpModule
	{

		public void Init(HttpApplication app)
		{
			app.BeginRequest += delegate(object sender, EventArgs e)
			{
				string path = app.Context.Request.Path;
				if(path.EndsWith(".page"))
					app.Context.RewritePath(path.Replace(".page", ".html"));
			};
		}

		public void Dispose() {}
	}

	public class GreetingHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			string greet = ConfigurationManager.AppSettings["Greeting:Salutation"] ?? "Greetings";
			string visitor = context.Request.QueryString["name"];

			TextWriter output = context.Response.Output;
			output.WriteLine("<html>");
			output.WriteLine("<head><title>BasicWebApp</title></head>");
			output.WriteLine("<body>");
			output.WriteLine($"<h1>{greet} Visitor {visitor}</h1>");
			output.WriteLine($"<b>Time on server: </b>{DateTime.Now}");
			output.WriteLine("</body>");
			output.WriteLine("</html>");
		}

		public bool IsReusable
		{
			get{return true;}
		}
	}

	public class StateHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
	{
		public void ProcessRequest(HttpContext context)
		{
			string name = context.Request.Form["visitor"];
			if(name?.Length == 0)
			{
				context.Response.Redirect("welcome.gwh");
				return;
			}

			int u = (int?)context.Session[name] ?? 1;
			context.Session[name] = u + 1;

			int g;
			lock(context.Application)
			{
				g = (int?)context.Application[name] ?? 1;
				context.Application[name] = g + 1;
			}
		
			TextWriter output = context.Response.Output;
			output.WriteLine("<html>");
			output.WriteLine("<head><title>BasicWebApp</title></head>");
			output.WriteLine("<body>");
			output.WriteLine($"<h1>Hello {name}</h1>");
			output.WriteLine($"<b>Number of greetings: </b>{u} / {g}");
			output.WriteLine("</body>");
			output.WriteLine("</html>");
		}

		public bool IsReusable
		{
			get{return false;}
		}
	}

	public class RainbowOutput : WebControl
	{
		public string Text {get; set;}

		protected override void Render(HtmlTextWriter writer)
		{
			string[] colors = {"violet", "indigo", "blue", "green", "yellow", "orange", "red"};
			int i = 0;

			foreach(char ch in this.Text)
			{
				if(char.IsWhiteSpace(ch))
					writer.Write(ch);
				else
				{
					writer.AddStyleAttribute(HtmlTextWriterStyle.Color, colors[(i++) % 7]);
					writer.RenderBeginTag(HtmlTextWriterTag.Span);
					writer.Write(ch);
					writer.RenderEndTag();
				}
			} 
		}

	}

	public class WebFormTestPage : Page
	{
		protected Label GreetLabel;
		protected TextBox NameTextBox;

		protected void GreetButton_Click(object sender, EventArgs e)
		{
			GreetLabel.Text = "Hello " + NameTextBox.Text;
		}
	}
}

