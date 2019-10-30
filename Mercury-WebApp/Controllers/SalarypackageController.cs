using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mercury_WebApp.Models;

namespace Mercury_WebApp.Controllers
{
    public class SalarypackageController : Controller
    {
        private readonly MercuryContext _context;

        public SalarypackageController(MercuryContext context)
        {
            _context = context;
        }

        // GET: Salarypackage
        public async Task<IActionResult> Index()
        {
            var mercuryContext = _context.Salarypackage.Include(s => s.Finantialcondition).Include(s => s.Salaryitem);
            return View(await mercuryContext.ToListAsync());
        }

        // GET: Salarypackage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salarypackage = await _context.Salarypackage
                .Include(s => s.Finantialcondition)
                .Include(s => s.Salaryitem)
                .FirstOrDefaultAsync(m => m.FinantialconditionId == id);
            if (salarypackage == null)
            {
                return NotFound();
            }

            return View(salarypackage);
        }

        public async Task<IActionResult> View(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryPackage = await _context.Salarypackage
                                    .Include(s => s.Finantialcondition)
                                    .Include(s => s.Salaryitem)
                                    .Where(m => m.FinantialconditionId == id)
                                    .ToListAsync();

            var finantialCond = await _context.Finantialcondition
                            .Include(c => c.Employee)
                            .Where(c => c.FinantialconditionId == id)
                            .FirstOrDefaultAsync();

            return View(Tuple.Create(salaryPackage, finantialCond));
        }

        // GET: Salarypackage/Create
        public IActionResult Create()
        {
            ViewData["FinantialconditionId"] = new SelectList(_context.Finantialcondition, "FinantialconditionId", "FinantialconditionId");
            ViewData["SalaryitemId"] = new SelectList(_context.Salaryitem, "SalaryitemId", "SalaryitemName");
            return View();
        }

        // POST: Salarypackage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinantialconditionId,SalaryitemId,Itemvalue,Notes,Percentvalue,Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec")] Salarypackage salarypackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salarypackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FinantialconditionId"] = new SelectList(_context.Finantialcondition, "FinantialconditionId", "FinantialconditionId", salarypackage.FinantialconditionId);
            ViewData["SalaryitemId"] = new SelectList(_context.Salaryitem, "SalaryitemId", "SalaryitemName", salarypackage.SalaryitemId);
            return View(salarypackage);
        }

        // GET: Salarypackage/Edit/5
        public async Task<IActionResult> Edit(int FinantialconditionId, int SalaryitemId)
        {
            var salarypackage = await _context.Salarypackage
                                .Where(a => a.FinantialconditionId == FinantialconditionId)
                                .Where(a => a.SalaryitemId == SalaryitemId)
                                .Include(s => s.Salaryitem)
                                .FirstOrDefaultAsync();
            if (salarypackage == null)
            {
                return NotFound();
            }
            ViewData["FinantialconditionId"] = new SelectList(_context.Finantialcondition, "FinantialconditionId", "FinantialconditionId", salarypackage.FinantialconditionId);
            ViewData["SalaryitemId"] = new SelectList(_context.Salaryitem, "SalaryitemId", "SalaryitemName", salarypackage.SalaryitemId);
            return View(salarypackage);
        }

        // POST: Salarypackage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("FinantialconditionId,SalaryitemId,Itemvalue,Notes,Percentvalue,Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec")] Salarypackage salarypackage)
        {
            /*
            if (id != salarypackage.FinantialconditionId)
            {
                return NotFound();
            }
            */
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salarypackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalarypackageExists(salarypackage.FinantialconditionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("View", new { id = salarypackage.FinantialconditionId });
            }
            ViewData["FinantialconditionId"] = new SelectList(_context.Finantialcondition, "FinantialconditionId", "FinantialconditionId", salarypackage.FinantialconditionId);
            ViewData["SalaryitemId"] = new SelectList(_context.Salaryitem, "SalaryitemId", "SalaryitemName", salarypackage.SalaryitemId);
            return View(salarypackage);
        }

        // GET: Salarypackage/Delete/5
        public async Task<IActionResult> Delete(int FinantialconditionId, int SalaryitemId)
        {
            var salarypackage = await _context.Salarypackage
                .Include(s => s.Finantialcondition)
                .Include(s => s.Salaryitem)
                .FirstOrDefaultAsync(m => m.FinantialconditionId == FinantialconditionId && m.SalaryitemId == SalaryitemId);
            if (salarypackage == null)
            {
                return NotFound();
            }

            return View(salarypackage);
        }

        // POST: Salarypackage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int FinantialconditionId, int SalaryitemId)
        {
            var salarypackage = await _context.Salarypackage
                                    .FirstOrDefaultAsync(m => m.FinantialconditionId == FinantialconditionId && m.SalaryitemId == SalaryitemId);
            _context.Salarypackage.Remove(salarypackage);
            await _context.SaveChangesAsync();
            return  RedirectToAction("View", new { id = FinantialconditionId });
        }

        private bool SalarypackageExists(int id)
        {
            return _context.Salarypackage.Any(e => e.FinantialconditionId == id);
        }

        public IActionResult DefaultValues(int id)
        {
            _context.Database.ExecuteSqlRaw("call create_salary_package_items({0})", id);
            return  RedirectToAction("View", new { id = id });
        }
    }
}
