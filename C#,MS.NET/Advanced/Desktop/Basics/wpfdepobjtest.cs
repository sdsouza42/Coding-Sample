using System;
using System.Threading;
using System.Windows;
using System.Windows.Data;

class Clock : DependencyObject
{
	public static readonly DependencyProperty TimeProperty = 
		DependencyProperty.Register("Time", typeof(string), typeof(Clock));

	public string Time
	{
		get {return (string)GetValue(TimeProperty);}
		set {SetValue(TimeProperty, value);}
	}

	public Clock()
	{
		ThreadPool.QueueUserWorkItem(Start);
	}

	private void Start(object state)
	{
		for(;;)
		{
			//called by worker thread from thread-pool
			Dispatcher.Invoke(delegate()
			{
				//executed by the owner thread of this object
				this.Time = DateTime.Now.ToString();
			});

			Thread.Sleep(1000);
		}
	}
}


class MainWindow : Window
{
	public MainWindow()
	{
		this.Title = "Hello WPF";

		Binding clockTime = new Binding("Time");
		clockTime.Source = new Clock();

		this.SetBinding(Window.ContentProperty, clockTime);
	}
}

static class Program
{
	[STAThread]
	public static void Main()
	{
		Application app = new Application();
		app.Run(new MainWindow());
	}
}

