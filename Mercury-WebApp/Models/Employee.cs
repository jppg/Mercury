using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Allocation = new HashSet<Allocation>();
            Finantialcondition = new HashSet<Finantialcondition>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Nchildren { get; set; }
        public int MaritalstatusId { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public virtual Maritalstatus Maritalstatus { get; set; }
        public virtual ICollection<Allocation> Allocation { get; set; }
        public virtual ICollection<Finantialcondition> Finantialcondition { get; set; }
    }
}
