using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mercury_WebApp.Models;
using Mercury_WebApp.Helpers;

namespace Mercury_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MercuryContext _context;

        public HomeController(ILogger<HomeController> logger, MercuryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {

            List<Resume> lstResume = new List<Resume>();

            List<Finantialcondition> lstFinantialConds = await _context.Finantialcondition
                                                            .Where(f => f.Enddate == null)
                                                            .ToListAsync();

            foreach(var fc in lstFinantialConds)
            {
                Resume res = new Resume();

                res.FinantialconditionId = fc.FinantialconditionId;

                Employee emp = await _context.Employee
                    .Where(e => e.EmployeeId == fc.EmployeeId)
                    .FirstOrDefaultAsync();
                
                res.EmployeeId = emp.EmployeeId;
                res.EmployeeName = emp.EmployeeName;
                
                EmployeeHelper employeeHelper = new EmployeeHelper(_context);

                List<Salarypackage> lstSalaryPck = await _context.Salarypackage
                    .Include(s => s.Finantialcondition)
                    .Include(s => s.Salaryitem)
                    .Where(s => s.FinantialconditionId == fc.FinantialconditionId)
                    .ToListAsync();

                res.TotalCost = employeeHelper.CalculateTotalCost(lstSalaryPck);

                Allocation aloc = await _context.Allocation
                    .Include(a => a.Client)
                    .Where(a => a.EmployeeId == fc.EmployeeId && (a.Enddate == null || a.Enddate > DateTime.Now))
                    .FirstOrDefaultAsync();

                if(aloc != null)
                {
                    res.Client = aloc.Client.ClientName;

                    ConfigHelper conf = new ConfigHelper(_context);

                    decimal nDays = conf.GetKeyValue("ANUAL_DAYS");

                    Console.WriteLine(string.Format("=====> N Days: {0}", nDays));
                    Console.WriteLine(string.Format("=====> Day rate: {0}", aloc.Dayrate));

                    res.Revenue = (aloc.Dayrate ?? 0) * nDays;


                    if(res.Revenue > 0)
                        res.Margin = (res.Revenue - res.TotalCost) / res.Revenue * 100;

                    Console.WriteLine(string.Format("=====> Revenue: {0}", res.Revenue));
                    Console.WriteLine(string.Format("=====> Margin: {0}", res.Margin));
                }

                if(string.IsNullOrEmpty(searchString) || res.EmployeeName.Contains(searchString) || (res.Client != null && res.Client.Contains(searchString)))
                    lstResume.Add(res);
                    
            }
            /*
            List<Salarypackage> lstSalaryPck = _context.Salarypackage
                .Include(s => s.Finantialcondition)
                .Include(s => s.Salaryitem)
                .ToListAsync();

            employeeCentric.FinantialCondition = await _context.Finantialcondition
                            .Include(c => c.Employee)
                            .Where(c => c.FinantialconditionId == id)
                            .FirstOrDefaultAsync();
            */

            return View(lstResume);
        }

        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
