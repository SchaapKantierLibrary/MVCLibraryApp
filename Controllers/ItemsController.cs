using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCLibraryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLibraryApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemsController
        public async Task<ActionResult> Index(string searchString)
        {
            IQueryable<ItemModel> items = _context.Items.Include(i => i.Auteur);

            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(i => i.Titel.Contains(searchString)
                                       || i.Auteur.Name.Contains(searchString)
                                       || i.Locatie.Beschrijving.Contains(searchString));
            }

            return View(await items.ToListAsync());
        }

    }
}