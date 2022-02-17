using System;
using System.Windows.Forms;

class MainForm : Form
{
	public MainForm()
	{
		this.Text = "Hello WinForms";
	}

	protected override void OnClosed(EventArgs e)
	{
		MessageBox.Show("Goodbye User!", "Hello WinForms", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		base.OnClosed(e);
	}
}

static class Program
{
	[STAThread]
	public static void Main()
	{
		Application.Run(new MainForm());
	}
}

