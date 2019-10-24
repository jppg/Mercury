﻿using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Simulation
    {
        public Simulation()
        {
            Salarypackage = new HashSet<Salarypackage>();
        }

        public int SimulationId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime? Enddate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<Salarypackage> Salarypackage { get; set; }
    }
}
