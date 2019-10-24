using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Simulation = new HashSet<Simulation>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Nchildren { get; set; }
        public int MaritalstatusId { get; set; }
        public int? ClientId { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public virtual Client Client { get; set; }
        public virtual Maritalstatus Maritalstatus { get; set; }
        public virtual ICollection<Simulation> Simulation { get; set; }
    }
}
