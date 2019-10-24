using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Taxrate
    {
        public int TaxrateId { get; set; }
        public decimal Salarymin { get; set; }
        public decimal Salarymax { get; set; }
        public int Maritalstatus { get; set; }
        public int Nchildrenmin { get; set; }
        public int Nchildrenmax { get; set; }
        public decimal Taxvalue { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public virtual Maritalstatus MaritalstatusNavigation { get; set; }
    }
}
