using System;

delegate void MessageEventHandler(object sender, MessageEventArgs e);

class MessageEventArgs : EventArgs
{
	public string Text {get; private set;}

	public string From {get; private set;}

	public MessageEventArgs(string text, string from)
	{
		this.Text = text;
		this.From = from;
	}
}

class MessengerSource
{
	public string Name {get; set;}

	public event MessageEventHandler Receive;

	public event EventHandler Sent;

	private void OnReceive(string text, string from)
	{
		if(Receive != null)
		{
			MessageEventArgs args = new MessageEventArgs(text, from);
			Receive(this, args);
		}
	}

	public void Send(string text, MessengerSource target)
	{
		target.OnReceive(text, this.Name);
		Sent?.Invoke(this, EventArgs.Empty);
	}
}

class MessengerSink
{
	private MessengerSource first, second;

	internal MessengerSink()
	{
		first = new MessengerSource{Name = "Jack"};
		first.Receive += first_Receive;
		first.Receive += ShowTime;
		
		second = new MessengerSource{Name = "Jill"};
		second.Sent += delegate(object sender, EventArgs e)
		{
			Console.WriteLine(">> Jill's message delivered");
		};

	}

	private void first_Receive(object sender, MessageEventArgs e)
	{
		Console.WriteLine(">> Jack received '{0}' from {1}", e.Text, e.From);
	}

	private void ShowTime(object sender, EventArgs e)
	{
		Console.WriteLine(DateTime.Now);
	}
	
	internal void Run()
	{
		second.Send("Hello", first);

		for(int t = Environment.TickCount + 5000; Environment.TickCount < t;);

		second.Send("Goodbye", first);
	}
}

static class Program
{
	public static void Main()
	{
		MessengerSink sink = new MessengerSink();
		sink.Run();
	}
}
