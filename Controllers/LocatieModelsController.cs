using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Data;
using MVCLibraryApp.Models;

namespace MVCLibraryApp.Controllers
{
    public class LocatieModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocatieModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocatieModels
        public async Task<IActionResult> Index()
        {
              return _context.Locaties != null ? 
                          View(await _context.Locaties.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Locaties'  is null.");
        }

        // GET: LocatieModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Locaties == null)
            {
                return NotFound();
            }

            var locatieModel = await _context.Locaties
                .FirstOrDefaultAsync(m => m.ID == id);
            if (locatieModel == null)
            {
                return NotFound();
            }

            return View(locatieModel);
        }

        // GET: LocatieModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocatieModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Beschrijving")] LocatieModel locatieModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locatieModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locatieModel);
        }

        // GET: LocatieModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Locaties == null)
            {
                return NotFound();
            }

            var locatieModel = await _context.Locaties.FindAsync(id);
            if (locatieModel == null)
            {
                return NotFound();
            }
            return View(locatieModel);
        }

        // POST: LocatieModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Beschrijving")] LocatieModel locatieModel)
        {
            if (id != locatieModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locatieModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocatieModelExists(locatieModel.ID))
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
            return View(locatieModel);
        }

        // GET: LocatieModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Locaties == null)
            {
                return NotFound();
            }

            var locatieModel = await _context.Locaties
                .FirstOrDefaultAsync(m => m.ID == id);
            if (locatieModel == null)
            {
                return NotFound();
            }

            return View(locatieModel);
        }

        // POST: LocatieModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Locaties == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Locaties'  is null.");
            }
            var locatieModel = await _context.Locaties.FindAsync(id);
            if (locatieModel != null)
            {
                _context.Locaties.Remove(locatieModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocatieModelExists(int id)
        {
          return (_context.Locaties?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
