using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;
using System.Diagnostics;
using System.Linq;

namespace MVCLibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // Define the context variable here

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context) // Inject the context in the constructor
        {
            _logger = logger;
            _context = context; // Assign the injected context to the private variable
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Dashboard()
        {
            // Get the list of locations to populate the dropdown
            ViewBag.Locations = _context.Locaties.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Dashboard(int locationId)
        {
            // Get the list of locations to populate the dropdown
            ViewBag.Locations = _context.Locaties.ToList();

            // Get the list of items for the selected location
            ViewBag.Items = _context.Items.Where(i => i.LocatieID == locationId).ToList();

            return View();
        }
    }
}
