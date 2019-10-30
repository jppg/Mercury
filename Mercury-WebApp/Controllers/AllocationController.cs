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
    public class AllocationController : Controller
    {
        private readonly MercuryContext _context;

        public AllocationController(MercuryContext context)
        {
            _context = context;
        }

        // GET: Allocation
        public async Task<IActionResult> Index()
        {
            var mercuryContext = _context.Allocation.Include(a => a.Client).Include(a => a.Employee);
            return View(await mercuryContext.ToListAsync());
        }

        // GET: Allocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _context.Allocation
                .Include(a => a.Client)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AllocationId == id);
            if (allocation == null)
            {
                return NotFound();
            }

            return View(allocation);
        }

        // GET: Allocation/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientName");
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName");
            return View();
        }

        // POST: Allocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllocationId,EmployeeId,ClientId,Dayrate,Startdate,Enddate")] Allocation allocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientName", allocation.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName", allocation.EmployeeId);
            return View(allocation);
        }

        // GET: Allocation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _context.Allocation.FindAsync(id);
            if (allocation == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientName", allocation.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName", allocation.EmployeeId);
            return View(allocation);
        }

        // POST: Allocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllocationId,EmployeeId,ClientId,Dayrate,Startdate,Enddate")] Allocation allocation)
        {
            if (id != allocation.AllocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllocationExists(allocation.AllocationId))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "ClientName", allocation.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName", allocation.EmployeeId);
            return View(allocation);
        }

        // GET: Allocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _context.Allocation
                .Include(a => a.Client)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AllocationId == id);
            if (allocation == null)
            {
                return NotFound();
            }

            return View(allocation);
        }

        // POST: Allocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allocation = await _context.Allocation.FindAsync(id);
            _context.Allocation.Remove(allocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllocationExists(int id)
        {
            return _context.Allocation.Any(e => e.AllocationId == id);
        }
    }
}
