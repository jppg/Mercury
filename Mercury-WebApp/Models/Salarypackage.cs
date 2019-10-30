using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Salarypackage
    {
        public int FinantialconditionId { get; set; }
        public int SalaryitemId { get; set; }
        public decimal? Itemvalue { get; set; }
        public string Notes { get; set; }
        public decimal? Percentvalue { get; set; }
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

        public virtual Finantialcondition Finantialcondition { get; set; }
        public virtual Salaryitem Salaryitem { get; set; }
    }
}
