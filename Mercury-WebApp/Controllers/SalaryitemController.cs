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
    public class SalaryitemController : Controller
    {
        private readonly MercuryContext _context;

        public SalaryitemController(MercuryContext context)
        {
            _context = context;
        }

        // GET: Salaryitem
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salaryitem.ToListAsync());
        }

        // GET: Salaryitem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryitem = await _context.Salaryitem
                .FirstOrDefaultAsync(m => m.SalaryitemId == id);
            if (salaryitem == null)
            {
                return NotFound();
            }

            return View(salaryitem);
        }

        // GET: Salaryitem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salaryitem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalaryitemId,SalaryitemName,Istaxed,Firmcostrate,Employeecostrate,Defaultvalue,Percentvalue,Incauto,Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec,Startdate,Enddate")] Salaryitem salaryitem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salaryitem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salaryitem);
        }

        // GET: Salaryitem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryitem = await _context.Salaryitem.FindAsync(id);
            if (salaryitem == null)
            {
                return NotFound();
            }
            return View(salaryitem);
        }

        // POST: Salaryitem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalaryitemId,SalaryitemName,Istaxed,Firmcostrate,Employeecostrate,Defaultvalue,Percentvalue,Incauto,Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec,Startdate,Enddate")] Salaryitem salaryitem)
        {
            if (id != salaryitem.SalaryitemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salaryitem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryitemExists(salaryitem.SalaryitemId))
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
            return View(salaryitem);
        }

        // GET: Salaryitem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryitem = await _context.Salaryitem
                .FirstOrDefaultAsync(m => m.SalaryitemId == id);
            if (salaryitem == null)
            {
                return NotFound();
            }

            return View(salaryitem);
        }

        // POST: Salaryitem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salaryitem = await _context.Salaryitem.FindAsync(id);
            _context.Salaryitem.Remove(salaryitem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryitemExists(int id)
        {
            return _context.Salaryitem.Any(e => e.SalaryitemId == id);
        }
    }
}
