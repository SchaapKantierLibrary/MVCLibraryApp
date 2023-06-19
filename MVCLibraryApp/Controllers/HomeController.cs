using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using MVCLibraryApp.Interfaces;
using MVCLibraryApp.Data;

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
    }
}
