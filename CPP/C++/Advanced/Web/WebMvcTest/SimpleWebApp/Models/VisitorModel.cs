using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleWebApp.Models
{
    public class VisitorModel
    {
        private static List<VisitorInfo> store = new List<VisitorInfo>
        {
            new VisitorInfo("Jack"), new VisitorInfo("Jill")
        };

        public VisitorInfo[] GetVisitors()
        {
            return store.ToArray();
        }

        public void RegisterVisit(string name)
        {
            VisitorInfo visitor = store.Find(entry => entry.Name == name);

            if (visitor == null)
                store.Add(new VisitorInfo(name));
            else
                visitor.Update();
        }
    }

    public class VisitorInfo
    {
        [Display(Name = "Visitor Name")]
        public string Name { get; set; }

        [Display(Name = "Visit Count")]
        public int Frequency { get; set; }

        [Display(Name = "Last Visit")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime Recent { get; set; }

        public VisitorInfo(string name)
        {
            this.Name = name;
            this.Frequency = 1;
            this.Recent = DateTime.Now;
        }

        public void Update()
        {
            this.Frequency += 1;
            this.Recent = DateTime.Now;
        }
    }
}
