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
        public decimal? Percentvalue { get; set; }
        public bool? Incauto { get; set; }
        public bool Jan { get; set; }
        public bool Feb { get; set; }
        public bool Mar { get; set; }
        public bool Apr { get; set; }
        public bool May { get; set; }
        public bool Jun { get; set; }
        public bool Jul { get; set; }
        public bool Aug { get; set; }
        public bool Sep { get; set; }
        public bool Oct { get; set; }
        public bool Nov { get; set; }
        public bool Dec { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public virtual ICollection<Salarypackage> Salarypackage { get; set; }
    }
}
