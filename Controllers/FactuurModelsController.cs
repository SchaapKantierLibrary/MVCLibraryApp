using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;

namespace MVCLibraryApp.Controllers
{
    public class FactuurModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FactuurModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FactuurModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Facturen.Include(f => f.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FactuurModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Facturen == null)
            {
                return NotFound();
            }

            var factuurModel = await _context.Facturen
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factuurModel == null)
            {
                return NotFound();
            }

            return View(factuurModel);
        }

        // GET: FactuurModels/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Bezoekers, "Id", "Id");
            return View();
        }

        // POST: FactuurModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ItemID,Amount,TransactionDate,Description")] FactuurModel factuurModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factuurModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Bezoekers, "Id", "Id", factuurModel.UserId);
            return View(factuurModel);
        }

        // GET: FactuurModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Facturen == null)
            {
                return NotFound();
            }

            var factuurModel = await _context.Facturen.FindAsync(id);
            if (factuurModel == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Bezoekers, "Id", "Id", factuurModel.UserId);
            return View(factuurModel);
        }

        // POST: FactuurModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ItemID,Amount,TransactionDate,Description")] FactuurModel factuurModel)
        {
            if (id != factuurModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factuurModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactuurModelExists(factuurModel.Id))
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
            ViewData["UserId"] = new SelectList(_context.Bezoekers, "Id", "Id", factuurModel.UserId);
            return View(factuurModel);
        }

        // GET: FactuurModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Facturen == null)
            {
                return NotFound();
            }

            var factuurModel = await _context.Facturen
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (factuurModel == null)
            {
                return NotFound();
            }

            return View(factuurModel);
        }

        // POST: FactuurModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Facturen == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Facturen'  is null.");
            }
            var factuurModel = await _context.Facturen.FindAsync(id);
            if (factuurModel != null)
            {
                _context.Facturen.Remove(factuurModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactuurModelExists(int id)
        {
          return (_context.Facturen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
