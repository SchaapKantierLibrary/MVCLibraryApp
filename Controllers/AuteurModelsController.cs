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
    public class AuteurModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuteurModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AuteurModels
        public async Task<IActionResult> Index()
        {
              return _context.Auteurs != null ? 
                          View(await _context.Auteurs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Auteurs'  is null.");
        }

        // GET: AuteurModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Auteurs == null)
            {
                return NotFound();
            }

            var auteurModel = await _context.Auteurs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (auteurModel == null)
            {
                return NotFound();
            }

            return View(auteurModel);
        }

        // GET: AuteurModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuteurModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Bio")] AuteurModel auteurModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auteurModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auteurModel);
        }

        // GET: AuteurModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Auteurs == null)
            {
                return NotFound();
            }

            var auteurModel = await _context.Auteurs.FindAsync(id);
            if (auteurModel == null)
            {
                return NotFound();
            }
            return View(auteurModel);
        }

        // POST: AuteurModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Bio")] AuteurModel auteurModel)
        {
            if (id != auteurModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auteurModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuteurModelExists(auteurModel.ID))
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
            return View(auteurModel);
        }

        // GET: AuteurModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Auteurs == null)
            {
                return NotFound();
            }

            var auteurModel = await _context.Auteurs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (auteurModel == null)
            {
                return NotFound();
            }

            return View(auteurModel);
        }

        // POST: AuteurModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Auteurs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Auteurs'  is null.");
            }
            var auteurModel = await _context.Auteurs.FindAsync(id);
            if (auteurModel != null)
            {
                _context.Auteurs.Remove(auteurModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuteurModelExists(int id)
        {
          return (_context.Auteurs?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
