using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CodeFirstApp
{
    public class Employee
    {
        public int Id { get; set; }

        public int Experience { get; set; }

        public decimal Salary { get; set; }

        public DateTime Appointed { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }

        public string Title { get; set; }

        //virtual navigation property
        //supports lazy (automatic) loading of child entities through dynamic proxy
        public virtual ICollection<Employee> Employees { get; set; }

        public Department()
        {
            this.Employees = new List<Employee>();
        }

    }

    public class HREntities : DbContext
    {
        public DbSet<Department> Departments { get; set; }
    }
}
