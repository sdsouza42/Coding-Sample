using System;
using System.Drawing;
using System.Windows.Forms;

class MainForm : Form
{
	private float radius = 100;
	private int sign = -1;
	private Timer anim;

	public MainForm()
	{
		this.Text = "Hello WinForms";
		this.BackColor = Color.FromArgb(255, 255, 255);
		this.Size = new Size(400, 400);
		
		anim = new Timer();
		anim.Interval = 100;
		anim.Tick += Animate;
		anim.Start();
		
	}

	private void Animate(object sender, EventArgs e)
	{
		radius += 0.9f * sign;

		if(radius < 10 || radius > 100)
			sign = -sign;
		else
			this.Refresh();
	}


	protected override void OnPaint(PaintEventArgs e)
	{
		using(Brush brush = new SolidBrush(Color.Red))
			e.Graphics.FillEllipse(brush, 200 - radius, 200 - radius, 2 * radius, 2 * radius);

		using(Pen pen = new Pen(Color.Blue, 5))
			e.Graphics.DrawEllipse(pen, 200 - radius, 200 - radius, 2 * radius, 2 * radius);

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

