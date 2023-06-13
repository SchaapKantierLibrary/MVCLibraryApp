using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using MVCLibraryApp.Interfaces;

namespace MVCLibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BezoekerModel> _userManager; // Add the _userManager field
        private readonly IUserRedirectionService _redirectionService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<BezoekerModel> userManager, IUserRedirectionService redirectionService) // Add redirectionService to the parameters
        {
            _logger = logger;
            _context = context;
            _userManager = userManager; // Assign the injected userManager to the private field
            _redirectionService = redirectionService; // Assign the injected redirectionService to the private field
        }
       

        public async Task<IActionResult> Index()
        {
            var result = await _redirectionService.GetRedirectBasedOnRole(User);
            if (result != null)
                return result;

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
