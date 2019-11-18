using System;
using System.Collections.Generic;
using System.Linq;
using Mercury_WebApp.Helpers;

namespace Mercury_WebApp.Models
{
    public class EmployeeCentric
    {
        public List<Salarypackage> SalaryPackage { get; set;}

        public List<Salaryitem> SalaryPackageItems { get; set;}

        public Finantialcondition FinantialCondition { get; set;}

        public Allocation Allocation { get; set;}
        public decimal TotalCost {get; set;}
        public decimal Revenue { 
            get
            {
                int N_DAYS = 231;

                decimal result = (Allocation.Dayrate ?? 0) * N_DAYS;
                
                return result;
            }
        }
        public decimal Margin { 
            get
            {
                if(Revenue > 0)
                    return (Revenue - TotalCost) / (Revenue * 100);

                return 0;
            }
        }
    }
}
