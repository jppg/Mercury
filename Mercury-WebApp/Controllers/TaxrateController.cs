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
    public class TaxrateController : Controller
    {
        private readonly MercuryContext _context;

        public TaxrateController(MercuryContext context)
        {
            _context = context;
        }

        // GET: Taxrate
        public async Task<IActionResult> Index()
        {
            var mercuryContext = _context.Taxrate.Include(t => t.MaritalstatusNavigation);
            return View(await mercuryContext.ToListAsync());
        }

        // GET: Taxrate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxrate = await _context.Taxrate
                .Include(t => t.MaritalstatusNavigation)
                .FirstOrDefaultAsync(m => m.TaxrateId == id);
            if (taxrate == null)
            {
                return NotFound();
            }

            return View(taxrate);
        }

        // GET: Taxrate/Create
        public IActionResult Create()
        {
            ViewData["Maritalstatus"] = new SelectList(_context.Maritalstatus, "MaritalstatusId", "MaritalstatusName");
            return View();
        }

        // POST: Taxrate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaxrateId,Salarymin,Salarymax,Maritalstatus,Nchildrenmin,Nchildrenmax,Taxvalue,Startdate,Enddate")] Taxrate taxrate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxrate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Maritalstatus"] = new SelectList(_context.Maritalstatus, "MaritalstatusId", "MaritalstatusName", taxrate.Maritalstatus);
            return View(taxrate);
        }

        // GET: Taxrate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxrate = await _context.Taxrate.FindAsync(id);
            if (taxrate == null)
            {
                return NotFound();
            }
            ViewData["Maritalstatus"] = new SelectList(_context.Maritalstatus, "MaritalstatusId", "MaritalstatusName", taxrate.Maritalstatus);
            return View(taxrate);
        }

        // POST: Taxrate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaxrateId,Salarymin,Salarymax,Maritalstatus,Nchildrenmin,Nchildrenmax,Taxvalue,Startdate,Enddate")] Taxrate taxrate)
        {
            if (id != taxrate.TaxrateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxrate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxrateExists(taxrate.TaxrateId))
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
            ViewData["Maritalstatus"] = new SelectList(_context.Maritalstatus, "MaritalstatusId", "MaritalstatusName", taxrate.Maritalstatus);
            return View(taxrate);
        }

        // GET: Taxrate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxrate = await _context.Taxrate
                .Include(t => t.MaritalstatusNavigation)
                .FirstOrDefaultAsync(m => m.TaxrateId == id);
            if (taxrate == null)
            {
                return NotFound();
            }

            return View(taxrate);
        }

        // POST: Taxrate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxrate = await _context.Taxrate.FindAsync(id);
            _context.Taxrate.Remove(taxrate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxrateExists(int id)
        {
            return _context.Taxrate.Any(e => e.TaxrateId == id);
        }
    }
}
