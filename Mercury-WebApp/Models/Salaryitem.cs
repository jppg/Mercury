using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Salaryitem
    {
        public Salaryitem()
        {
            Salarypackage = new HashSet<Salarypackage>();
        }

        public int SalaryitemId { get; set; }
        public string SalaryitemName { get; set; }
        public bool Istaxed { get; set; }
        public decimal? Firmcostrate { get; set; }
        public decimal? Employeecostrate { get; set; }
        public decimal? Defaultvalue { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public virtual ICollection<Salarypackage> Salarypackage { get; set; }
    }
}
