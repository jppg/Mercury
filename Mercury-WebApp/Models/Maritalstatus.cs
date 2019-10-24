using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Maritalstatus
    {
        public Maritalstatus()
        {
            Employee = new HashSet<Employee>();
            Taxrate = new HashSet<Taxrate>();
        }

        public int MaritalstatusId { get; set; }
        public string MaritalstatusName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Taxrate> Taxrate { get; set; }
    }
}
