using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Allocation
    {
        public int AllocationId { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public decimal? Dayrate { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
