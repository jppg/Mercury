using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercury_WebApp.Models;

namespace Mercury_WebApp.Helpers
{
  public class EmployeeHelper
  {
      private readonly MercuryContext _context;

      public EmployeeHelper(MercuryContext context)
      {
          _context = context;
      }

      public decimal CalculateTotalCost(List<Salarypackage> salPkg)
      {
        //Console.WriteLine("====================================================");

        decimal totalCost = 0;
        decimal valueTaxable = 0;
        foreach(var item in salPkg)
        {
            int nMonths = (item.Jan ? 1 : 0) + (item.Feb ? 1 : 0) + (item.Mar ? 1 : 0)
                        + (item.Apr ? 1 : 0) + (item.May ? 1 : 0) + (item.Jun ? 1 : 0)
                        + (item.Jul ? 1 : 0) + (item.Aug ? 1 : 0) + (item.Sep ? 1 : 0)
                        + (item.Oct ? 1 : 0) + (item.Nov ? 1 : 0) + (item.Dec ? 1 :0);
            
            decimal amount = (item.Itemvalue ?? 0) * (item.Percentvalue ?? 0) * nMonths;
            totalCost += amount;
            if(item.Salaryitem.Istaxed)
                valueTaxable += amount;
            
            Console.WriteLine(string.Format("{0}: {1} (nr of months = {2})", item.Salaryitem.SalaryitemName, amount, nMonths));
        }
        //Calculate other costs
        //Get TSU rate
        ConfigHelper conf = new ConfigHelper(_context);

        decimal singleSocialTax = conf.GetKeyValue("TSU");
        totalCost += valueTaxable * singleSocialTax;

        //Get Work insurance prime
        decimal accidentsAtWorkInsuranceTax = conf.GetKeyValue("SEG_ACID_TRAB");
        totalCost += valueTaxable * accidentsAtWorkInsuranceTax;

        //Get Work security prime
        decimal safetyAndHealthAtWorkTax = conf.GetKeyValue("SEG_HIG_TRAB");
        totalCost += safetyAndHealthAtWorkTax * 12;

        /*
        Console.WriteLine(string.Format("Taxable Amount: {0}", valueTaxable));
        Console.WriteLine(string.Format("Single Social Tax: {0} ({1})", (valueTaxable * singleSocialTax), singleSocialTax));
        Console.WriteLine(string.Format("Accidents at Work Insurance Tax: {0} ({1})", (valueTaxable * accidentsAtWorkInsuranceTax), accidentsAtWorkInsuranceTax));
        Console.WriteLine(string.Format("Safety and Health at Work Tax: {0} ({1})", (safetyAndHealthAtWorkTax * 12), safetyAndHealthAtWorkTax));
        Console.WriteLine("====================================================");
        */

        return totalCost;
      }
  }
}