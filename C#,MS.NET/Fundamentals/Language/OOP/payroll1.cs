namespace Payroll
{
	public class Employee
	{
		private int id;
		internal int hours;
		protected float rate;
		static int count;

		public Employee(int h, float r)
		{
			id = 101 + count++;
			hours = h;
			rate = r;
		}

		public Employee() : this(0, 0) {}

		public int Id
		{
			get {return id;}
		}

		public int Hours
		{
			get {return hours;}
			set {hours = value;}
		}

		public float Rate
		{
			get {return rate;}
			set {rate = value;}
		}

		public double GetNetIncome()
		{
			double income = hours * rate;
			int ot = hours - 180;

			if(ot > 0)
				income += 50 * ot;

			return income;
		}

		public static int CountInstances()
		{
			return count;
		}
	}

	public class SalesPerson : Employee
	{
		public double Sales {get; set;}

		public SalesPerson(int h, float r, double s) : base(h, r)
		{
			this.Sales = s;
		}

		public new double GetNetIncome()
		{
			double income = base.GetNetIncome();
			
			if(this.Sales >= 20000)
				income += 0.05 * this.Sales;

			return income;
		}
	}
}
