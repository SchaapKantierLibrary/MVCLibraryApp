using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public BezoekerController(ApplicationDbContext context, UserManager<BezoekerModel> userManager, SignInManager<BezoekerModel> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
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
                    await _signInManager.SignInAsync(user, isPersistent: false); // Log in the user
                    return RedirectToAction("Dashboard");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If registration fails, redirect to the login page
            return RedirectToAction("Login", "Bezoeker");
        }
        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);

            ViewData["UserName"] = user.Naam;
            ViewData["Email"] = user.Email;
            ViewData["UserID"] = user.Id;
            ViewData["MembershipStatus"] = user.Lidmaatschapsstatus;

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
                    return RedirectToAction("Dashboard");
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

        public IActionResult Login()
        {
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
