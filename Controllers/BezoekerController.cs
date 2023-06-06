using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCLibraryApp.Controllers
{
    public class BezoekerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BezoekerModel> _userManager;
        private readonly SignInManager<BezoekerModel> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public BezoekerController(ApplicationDbContext context, UserManager<BezoekerModel> userManager, SignInManager<BezoekerModel> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            // Check if the user is already authenticated
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Beheerder"))
                    return RedirectToAction("Dashboard", "Beheerder");
                if (roles.Contains("Medewerker"))
                    return RedirectToAction("Dashboard", "Medewerker");
                if (roles.Contains("Bezoeker"))
                    return RedirectToAction("Dashboard", "Bezoeker");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new BezoekerModel
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Naam = model.Naam,
                    AbonnementID = 1
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Adding the user to the 'Bezoeker' role
                    await _userManager.AddToRoleAsync(user, "Bezoeker");
                    await _signInManager.SignInAsync(user, isPersistent: false); // Log in the user
                    return RedirectToAction("Dashboard");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If registration fails, return to the registration view with the model
            return View(model);
        }

        [Authorize(Roles = "Bezoeker")]
        public async Task<IActionResult> Dashboard()
        {
            ViewBag.Locations = await _context.Locaties.ToListAsync();
            ViewBag.Items = new List<ItemModel>(); // Send an empty list to the view
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Dashboard(int locationId)
        {
            ViewBag.Locations = await _context.Locaties.ToListAsync();
            ViewBag.Items = await _context.Items.Where(i => i.LocatieID == locationId).ToListAsync();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        var roles = await _userManager.GetRolesAsync(user);

                        if (roles.Contains("Bezoeker"))
                        {
                            return RedirectToAction("Dashboard", "Bezoeker");
                        }
                        else if (roles.Contains("Medewerker"))
                        {
                            return RedirectToAction("Dashboard", "Medewerker");
                        }
                        else if (roles.Contains("Beheerder"))
                        {
                            return RedirectToAction("Dashboard", "Beheerder");
                        }
                    }
                }

                if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Your account is locked out. Please try again later.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            // Check if the user is already authenticated
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Beheerder"))
                    return RedirectToAction("Dashboard", "Beheerder");
                if (roles.Contains("Medewerker"))
                    return RedirectToAction("Dashboard", "Medewerker");
                if (roles.Contains("Bezoeker"))
                    return RedirectToAction("Dashboard", "Bezoeker");
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

