using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Global
    {
        public Finantialcondition Finantialconditions {get; set;}
        public Salarypackage salarypackages {get; set;}
        public List<Salaryitem> Salaryitems {get; set;}
        public List<Allocation> Allocations {get; set;}
    }
}
