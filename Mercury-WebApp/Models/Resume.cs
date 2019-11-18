using System;
using System.Collections.Generic;

namespace Mercury_WebApp.Models
{
    public partial class Resume
    {
        public int EmployeeId {get; set;}

        public string EmployeeName {get; set;}

        public string Client {get; set;}

        public int FinantialconditionId {get; set;}

        public decimal TotalCost {get; set;}

        public decimal Revenue {get; set;}

        public decimal Margin {get; set;}

    }
}