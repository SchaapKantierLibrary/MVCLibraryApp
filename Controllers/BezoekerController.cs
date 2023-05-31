using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCLibraryApp.Models;


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
                // Create a new user object
                var user = new BezoekerModel
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Naam = model.Naam, // Assign the value of "Naam" from the model
                    AbonnementID = 1
                };

                // Register the user
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Add the default role to the user if needed
                    // await _userManager.AddToRoleAsync(user, "UserRole");

                    // Sign in the user after registration if needed
                    // await _signInManager.SignInAsync(user, isPersistent: false);

                    // Redirect to a success page or return a success response
                    return RedirectToAction("RegistrationSuccess");
                }

                // If registration fails, add model errors to display in the view
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If the model state is not valid, return the registration view with errors
            return View(model);
        }
    }
}
