using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;
using MVCLibraryApp.Services;
using System.Security.Claims;
using System.Threading.Tasks;
using MVCLibraryApp.Interfaces;
using MVCLibraryApp.Data;

namespace MVCLibraryApp.Controllers
{
    [Authorize(Roles = "Visitor,Employee,Admin")]
    public class VisitorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<VisitorModel> _userManager;
        private readonly SignInManager<VisitorModel> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountService _accountService;
        private readonly IUserRedirectionService _redirectionService;

        public VisitorController(ApplicationDbContext context, UserManager<VisitorModel> userManager, SignInManager<VisitorModel> signInManager, RoleManager<IdentityRole> roleManager, IAccountService accountService, IUserRedirectionService redirectionService)
        {
            _accountService = accountService;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _redirectionService = redirectionService;

        }


        public async Task<IActionResult> Dashboard()
        {
            var result = await _redirectionService.GetRedirectBasedOnRole(User);
            if (result != null)
                return result;

            return View();
        }



        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            var result = await _redirectionService.GetRedirectBasedOnRole(User);
            if (result != null)
                return result;

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.RegisterUser(model);
                if (result.Succeeded)
                {
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutUser();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> IndexItems(string title = "", string authorSearch = "")
        {
            ViewBag.Title = title;
            ViewBag.AuthorSearch = authorSearch;
            ViewBag.Locations = await _context.Locaties.ToListAsync();

            IQueryable<ItemModel> itemsQuery = _context.Items.Include(i => i.Author);

            if (!string.IsNullOrEmpty(authorSearch))
            {
                var authorIds = _context.Auteurs
                    .Where(a => a.Name.Contains(authorSearch))
                    .Select(a => a.ID);

                itemsQuery = itemsQuery.Where(i => authorIds.Contains(i.AuthorID));
            }

            if (!string.IsNullOrEmpty(title))
            {
                itemsQuery = itemsQuery.Where(i => i.Title.Contains(title));
            }

            ViewBag.Items = await itemsQuery.ToListAsync();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> IndexItems(int locationId, string title, string authorSearch)
        {
            ViewBag.Locations = await _context.Locaties.ToListAsync();
            ViewBag.SelectedLocationId = locationId;
            ViewBag.Title = title;
            ViewBag.AuthorSearch = authorSearch;

            IQueryable<ItemModel> itemsQuery;

            // If title or authorSearch is provided, don't filter by location.
            if (!string.IsNullOrEmpty(authorSearch) || !string.IsNullOrEmpty(title))
            {
                itemsQuery = _context.Items.Include(i => i.Author);
            }
            else
            {
                itemsQuery = _context.Items.Include(i => i.Author).Where(i => i.LocationID == locationId);
            }

            if (!string.IsNullOrEmpty(authorSearch))
            {
                var authorIds = _context.Auteurs
                    .Where(a => a.Name.Contains(authorSearch))
                    .Select(a => a.ID);

                itemsQuery = itemsQuery.Where(i => authorIds.Contains(i.AuthorID));
            }

            if (!string.IsNullOrEmpty(title))
            {
                itemsQuery = itemsQuery.Where(i => i.Title.Contains(title));
            }

            ViewBag.Items = await itemsQuery.ToListAsync();



            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReserveItem(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Find the current user
            var currentUser = await _context.Bezoekers.Include(b => b.Abonnement).FirstOrDefaultAsync(b => b.Id == userId);

            if (currentUser == null)
            {
                return NotFound("User not found.");
            }

            // Get the maximum allowed reservations from the user's subscription
            int maxReservations = currentUser.Abonnement.MaxItems;

            // Count the existing reservations for the current user
            int existingReservations = _context.Reserveringen.Count(r => r.VisitorID == userId);

            if (existingReservations >= maxReservations)
            {
                // Pass error message to the view
                ViewData["ErrorMessage"] = "You have reached the maximum number of reservations allowed by your subscription.";

                // Load the items for the "IndexItems" view
                ViewBag.Locations = await _context.Locaties.ToListAsync();
                IQueryable<ItemModel> itemsQuery = _context.Items.Include(i => i.Author);
                ViewBag.Items = await itemsQuery.ToListAsync();

                // Return to the "IndexItems" view
                return View("IndexItems");
            }


            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var reservation = new ReservationModel
            {
                ItemID = item.ID,
                VisitorID = userId,
                ReservationDate = DateTime.Now
            };

            // Change the status of the item to Not Available
            item.Status = "Not Available";

            try
            {
                _context.Reserveringen.Add(reservation);
                await _context.SaveChangesAsync(); // save changes in the database
            }
            catch (DbUpdateConcurrencyException)
            {
                // handle exception
            }

            return RedirectToAction(nameof(IndexItems));
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

                        if (roles.Contains("Visitor"))
                        {
                            return RedirectToAction("Dashboard", "Visitor");
                        }
                        else if (roles.Contains("Employee"))
                        {
                            return RedirectToAction("Dashboard", "Employee");
                        }
                        else if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Dashboard", "Admin");
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
            var result = await _redirectionService.GetRedirectBasedOnRole(User);
            if (result != null)
                return result;

            return View();
        }



        public async Task<IActionResult> UserReservations()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservations = await _context.Reserveringen
                .Where(r => r.VisitorID == userId)
                .Include(r => r.Item)  // assuming the relationship is properly defined
                .ToListAsync();

            return View(reservations);
        }
        [HttpPost]
      
        public async Task<IActionResult> CancelReservation(int id)
        {
            var reservation = await _context.Reserveringen.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            if (reservation.VisitorID != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Unauthorized();
            }

            _context.Reserveringen.Remove(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Reservations));
        }

        public async Task<IActionResult> Reservations()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservations = await _context.Reserveringen
                .Where(r => r.VisitorID == userId)
                .Include(r => r.Item)
                .ToListAsync();

            return View(reservations);
        }

    
    }

}

