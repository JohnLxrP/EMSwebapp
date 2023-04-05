using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMSwebapp.Data;
using EMSwebapp.Models;

namespace EMSwebapp.Controllers
{
    public class BenefitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BenefitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Benefits
        public async Task<IActionResult> Index()
        {
              return _context.Benefit != null ? 
                          View(await _context.Benefit.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Benefit'  is null.");
        }

        // GET: Benefits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Benefit == null)
            {
                return NotFound();
            }

            var benefit = await _context.Benefit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (benefit == null)
            {
                return NotFound();
            }

            return View(benefit);
        }

        // GET: Benefits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Benefits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Benefit benefit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(benefit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(benefit);
        }

        // GET: Benefits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Benefit == null)
            {
                return NotFound();
            }

            var benefit = await _context.Benefit.FindAsync(id);
            if (benefit == null)
            {
                return NotFound();
            }
            return View(benefit);
        }

        // POST: Benefits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Benefit benefit)
        {
            if (id != benefit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(benefit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BenefitExists(benefit.Id))
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
            return View(benefit);
        }

        // GET: Benefits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Benefit == null)
            {
                return NotFound();
            }

            var benefit = await _context.Benefit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (benefit == null)
            {
                return NotFound();
            }

            return View(benefit);
        }

        // POST: Benefits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Benefit == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Benefit'  is null.");
            }
            var benefit = await _context.Benefit.FindAsync(id);
            if (benefit != null)
            {
                _context.Benefit.Remove(benefit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BenefitExists(int id)
        {
          return (_context.Benefit?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
