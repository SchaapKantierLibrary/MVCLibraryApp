using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCLibraryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MVCLibraryApp.Data;

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
            IQueryable<ItemModel> items = _context.Items.Include(i => i.Author);

            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(i => i.Title.Contains(searchString)
                                       || i.Author.Name.Contains(searchString)
                                       || i.Location.LocationName.Contains(searchString));
            }

            return View(await items.ToListAsync());
        }

    }
}