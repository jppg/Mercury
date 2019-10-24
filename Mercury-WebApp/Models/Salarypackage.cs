using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Salarypackage
    {
        public int SimulationId { get; set; }
        public int SalaryitemId { get; set; }
        public decimal? Itemvalue { get; set; }

        public virtual Salaryitem Salaryitem { get; set; }
        public virtual Simulation Simulation { get; set; }
    }
}
