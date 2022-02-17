using System;
using System.Drawing;
using System.Windows.Forms;

class MainForm : Form
{
	Label outputLabel;
	Button computeButton;

	public MainForm()
	{
		this.Text = "Hello WinForms";

		outputLabel = new Label();
		outputLabel.Text = "Ready";
		outputLabel.Location = new Point(20, 20);
		outputLabel.Size = new Size(200, 20);
		this.Controls.Add(outputLabel);

		computeButton = new Button();
		computeButton.Text = "Compute";
		computeButton.Location = new Point(20, 50);
		computeButton.Size = new Size(60, 25);
		computeButton.Click += computeButton_Click;
		this.Controls.Add(computeButton);
	}

	private async void computeButton_Click(object sender, EventArgs e)
	{
		outputLabel.Text = "Busy";
		computeButton.Enabled = false;

		Computation c = new Computation();
		int n = 20 + Environment.TickCount % 6;
		long result = await c.ComputeAsync(1, n);
		
		outputLabel.Text = $"Result is {result}";
		computeButton.Enabled = true;
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

