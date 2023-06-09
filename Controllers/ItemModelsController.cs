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
    public class ItemModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Items.Include(i => i.Auteur).Include(i => i.Locatie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ItemModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items
                .Include(i => i.Auteur)
                .Include(i => i.Locatie)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        // GET: ItemModels/Create
        public IActionResult Create()
        {
            ViewData["AuteurID"] = new SelectList(_context.Auteurs, "ID", "ID");
            ViewData["LocatieID"] = new SelectList(_context.Locaties, "ID", "ID");
            return View();
        }

        // POST: ItemModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titel,AuteurID,Publicatiejaar,Status,LocatieID")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuteurID"] = new SelectList(_context.Auteurs, "ID", "ID", itemModel.AuteurID);
            ViewData["LocatieID"] = new SelectList(_context.Locaties, "ID", "ID", itemModel.LocatieID);
            return View(itemModel);
        }

        // GET: ItemModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items.FindAsync(id);
            if (itemModel == null)
            {
                return NotFound();
            }
            ViewData["AuteurID"] = new SelectList(_context.Auteurs, "ID", "ID", itemModel.AuteurID);
            ViewData["LocatieID"] = new SelectList(_context.Locaties, "ID", "ID", itemModel.LocatieID);
            return View(itemModel);
        }

        // POST: ItemModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titel,AuteurID,Publicatiejaar,Status,LocatieID")] ItemModel itemModel)
        {
            if (id != itemModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemModelExists(itemModel.ID))
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
            ViewData["AuteurID"] = new SelectList(_context.Auteurs, "ID", "ID", itemModel.AuteurID);
            ViewData["LocatieID"] = new SelectList(_context.Locaties, "ID", "ID", itemModel.LocatieID);
            return View(itemModel);
        }

        // GET: ItemModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Items == null)
            {
                return NotFound();
            }

            var itemModel = await _context.Items
                .Include(i => i.Auteur)
                .Include(i => i.Locatie)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemModel == null)
            {
                return NotFound();
            }

            return View(itemModel);
        }

        // POST: ItemModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Items == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Items'  is null.");
            }
            var itemModel = await _context.Items.FindAsync(id);
            if (itemModel != null)
            {
                _context.Items.Remove(itemModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemModelExists(int id)
        {
          return (_context.Items?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
