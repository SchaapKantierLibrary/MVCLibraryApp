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
    public class AbonnementModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AbonnementModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AbonnementModels
        public async Task<IActionResult> Index()
        {
              return _context.Abonnementen != null ? 
                          View(await _context.Abonnementen.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Abonnementen'  is null.");
        }

        // GET: AbonnementModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Abonnementen == null)
            {
                return NotFound();
            }

            var abonnementModel = await _context.Abonnementen
                .FirstOrDefaultAsync(m => m.ID == id);
            if (abonnementModel == null)
            {
                return NotFound();
            }

            return View(abonnementModel);
        }

        // GET: AbonnementModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AbonnementModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Type,MaximaleItems,Uitleentermijn,Verlengingen,Reserveringskosten,Boetekosten,Abonnementskosten")] AbonnementModel abonnementModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abonnementModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(abonnementModel);
        }

        // GET: AbonnementModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Abonnementen == null)
            {
                return NotFound();
            }

            var abonnementModel = await _context.Abonnementen.FindAsync(id);
            if (abonnementModel == null)
            {
                return NotFound();
            }
            return View(abonnementModel);
        }

        // POST: AbonnementModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Type,MaximaleItems,Uitleentermijn,Verlengingen,Reserveringskosten,Boetekosten,Abonnementskosten")] AbonnementModel abonnementModel)
        {
            if (id != abonnementModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abonnementModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbonnementModelExists(abonnementModel.ID))
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
            return View(abonnementModel);
        }

        // GET: AbonnementModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Abonnementen == null)
            {
                return NotFound();
            }

            var abonnementModel = await _context.Abonnementen
                .FirstOrDefaultAsync(m => m.ID == id);
            if (abonnementModel == null)
            {
                return NotFound();
            }

            return View(abonnementModel);
        }

        // POST: AbonnementModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Abonnementen == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Abonnementen'  is null.");
            }
            var abonnementModel = await _context.Abonnementen.FindAsync(id);
            if (abonnementModel != null)
            {
                _context.Abonnementen.Remove(abonnementModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbonnementModelExists(int id)
        {
          return (_context.Abonnementen?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
