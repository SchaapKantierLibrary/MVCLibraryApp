using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;
using MVCLibraryApp.Services;
using System.Security.Claims;
using System.Threading.Tasks;
using MVCLibraryApp.Interfaces;

namespace MVCLibraryApp.Controllers
{
    [Authorize(Roles = "Bezoeker,Medewerker,beheerder")]
    public class BezoekerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<BezoekerModel> _userManager;
        private readonly SignInManager<BezoekerModel> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountService _accountService;

        public BezoekerController(ApplicationDbContext context, UserManager<BezoekerModel> userManager, SignInManager<BezoekerModel> signInManager, RoleManager<IdentityRole> roleManager, IAccountService accountService)
        {
            _accountService = accountService;
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

        [Authorize(Roles = "Bezoeker")]
        public async Task<IActionResult> Dashboard(string title = "", string authorSearch = "")
        {
            ViewBag.Title = title;
            ViewBag.AuthorSearch = authorSearch;
            ViewBag.Locations = await _context.Locaties.ToListAsync();

            IQueryable<ItemModel> itemsQuery = _context.Items.Include(i => i.Auteur);

            if (!string.IsNullOrEmpty(authorSearch))
            {
                var authorIds = _context.Auteurs
                    .Where(a => a.Name.Contains(authorSearch))
                    .Select(a => a.ID);

                itemsQuery = itemsQuery.Where(i => authorIds.Contains(i.AuteurID));
            }

            if (!string.IsNullOrEmpty(title))
            {
                itemsQuery = itemsQuery.Where(i => i.Titel.Contains(title));
            }

            ViewBag.Items = await itemsQuery.ToListAsync();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Dashboard(int locationId, string title, string authorSearch)
        {
            ViewBag.Locations = await _context.Locaties.ToListAsync();
            ViewBag.SelectedLocationId = locationId;
            ViewBag.Title = title;
            ViewBag.AuthorSearch = authorSearch;

            IQueryable<ItemModel> itemsQuery;

            // If title or authorSearch is provided, don't filter by location.
            if (!string.IsNullOrEmpty(authorSearch) || !string.IsNullOrEmpty(title))
            {
                itemsQuery = _context.Items.Include(i => i.Auteur);
            }
            else
            {
                itemsQuery = _context.Items.Include(i => i.Auteur).Where(i => i.LocatieID == locationId);
            }

            if (!string.IsNullOrEmpty(authorSearch))
            {
                var authorIds = _context.Auteurs
                    .Where(a => a.Name.Contains(authorSearch))
                    .Select(a => a.ID);

                itemsQuery = itemsQuery.Where(i => authorIds.Contains(i.AuteurID));
            }

            if (!string.IsNullOrEmpty(title))
            {
                itemsQuery = itemsQuery.Where(i => i.Titel.Contains(title));
            }

            ViewBag.Items = await itemsQuery.ToListAsync();



            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReserveItem(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Count the existing reservations for the current user
            int existingReservations = _context.Reserveringen.Count(r => r.BezoekerID == userId);

            if (existingReservations >= 3)
            {
                // You can return a specific error view, pass an error message to the view, or simply return BadRequest.
                // Here I'm returning BadRequest with a simple error message.
                return BadRequest("You already have 3 or more reservations.");
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var reservation = new ReserveringModel
            {
                ItemID = item.ID,
                BezoekerID = userId,
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

            return RedirectToAction(nameof(Dashboard));
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



        public async Task<IActionResult> UserReservations()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservations = await _context.Reserveringen
                .Where(r => r.BezoekerID == userId)
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
            if (reservation.BezoekerID != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Unauthorized();
            }

            _context.Reserveringen.Remove(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Beheer));
        }

        public async Task<IActionResult> Beheer()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservations = await _context.Reserveringen
                .Where(r => r.BezoekerID == userId)
                .Include(r => r.Item)
                .ToListAsync();

            return View(reservations);
        }
    }

}

