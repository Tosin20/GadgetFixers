using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GadgetFixers.Data;
using GadgetFixers.Models;

namespace GadgetFixers.Controllers
{
    public class FixersController : Controller
    {
        private readonly GadgetFixersContext _context;

        public FixersController(GadgetFixersContext context)
        {
            _context = context;
        }

        // GET: Fixers
        public async Task<IActionResult> Index()
        {
              return _context.Fixer != null ? 
                          View(await _context.Fixer.ToListAsync()) :
                          Problem("Entity set 'GadgetFixersContext.Fixer'  is null.");
        }

        // GET: Fixers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fixer == null)
            {
                return NotFound();
            }

            var fixer = await _context.Fixer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fixer == null)
            {
                return NotFound();
            }

            return View(fixer);
        }

        // GET: Fixers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fixers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Department")] Fixer fixer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fixer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fixer);
        }

        // GET: Fixers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fixer == null)
            {
                return NotFound();
            }

            var fixer = await _context.Fixer.FindAsync(id);
            if (fixer == null)
            {
                return NotFound();
            }
            return View(fixer);
        }

        // POST: Fixers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Department")] Fixer fixer)
        {
            if (id != fixer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fixer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FixerExists(fixer.Id))
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
            return View(fixer);
        }

        // GET: Fixers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fixer == null)
            {
                return NotFound();
            }

            var fixer = await _context.Fixer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fixer == null)
            {
                return NotFound();
            }

            return View(fixer);
        }

        // POST: Fixers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fixer == null)
            {
                return Problem("Entity set 'GadgetFixersContext.Fixer'  is null.");
            }
            var fixer = await _context.Fixer.FindAsync(id);
            if (fixer != null)
            {
                _context.Fixer.Remove(fixer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FixerExists(int id)
        {
          return (_context.Fixer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
