using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstApp
{
    public partial class MainForm : Form
    {
        HREntities db;
        Department sales;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            db = new HREntities();

            sales = db.Departments.FirstOrDefault(entry => entry.Title == "Sales");
            if(sales == null)
            {
                sales = new Department { Title = "Sales" };
                db.Departments.Add(sales);
            }

            employeeBindingSource.DataSource = sales.Employees;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(db.ChangeTracker.HasChanges())
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to save the changes?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    db.SaveChanges();
            }

            db.Dispose();
        }

        private void employeeDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[2].Value = DateTime.Today;
        }
    }
}
