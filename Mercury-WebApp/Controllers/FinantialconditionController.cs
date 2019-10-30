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
    public class FinantialconditionController : Controller
    {
        private readonly MercuryContext _context;

        public FinantialconditionController(MercuryContext context)
        {
            _context = context;
        }

        // GET: Finantialcondition
        public async Task<IActionResult> Index()
        {
            var mercuryContext = _context.Finantialcondition.Include(f => f.Employee);
            return View(await mercuryContext.ToListAsync());
        }

        // GET: Finantialcondition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finantialcondition = await _context.Finantialcondition
                .Include(f => f.Employee)
                .FirstOrDefaultAsync(m => m.FinantialconditionId == id);
            if (finantialcondition == null)
            {
                return NotFound();
            }

            return View(finantialcondition);
        }

        // GET: Finantialcondition/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName");
            return View();
        }

        // POST: Finantialcondition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinantialconditionId,EmployeeId,Startdate,Enddate")] Finantialcondition finantialcondition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finantialcondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName", finantialcondition.EmployeeId);
            return View(finantialcondition);
        }

        // GET: Finantialcondition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finantialcondition = await _context.Finantialcondition.FindAsync(id);
            if (finantialcondition == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName", finantialcondition.EmployeeId);
            return View(finantialcondition);
        }

        // POST: Finantialcondition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FinantialconditionId,EmployeeId,Startdate,Enddate")] Finantialcondition finantialcondition)
        {
            if (id != finantialcondition.FinantialconditionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finantialcondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinantialconditionExists(finantialcondition.FinantialconditionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName", finantialcondition.EmployeeId);
            return View(finantialcondition);
        }

        // GET: Finantialcondition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finantialcondition = await _context.Finantialcondition
                .Include(f => f.Employee)
                .FirstOrDefaultAsync(m => m.FinantialconditionId == id);
            if (finantialcondition == null)
            {
                return NotFound();
            }

            return View(finantialcondition);
        }

        // POST: Finantialcondition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var finantialcondition = await _context.Finantialcondition.FindAsync(id);
            _context.Finantialcondition.Remove(finantialcondition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinantialconditionExists(int id)
        {
            return _context.Finantialcondition.Any(e => e.FinantialconditionId == id);
        }
    }
}
