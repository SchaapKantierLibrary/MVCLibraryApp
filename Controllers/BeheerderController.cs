using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Interfaces;
using MVCLibraryApp.Models;
using MVCLibraryApp.ViewModels;
using MVCLibraryApp.Services;


[Authorize(Roles = "Beheerder")]
public class BeheerderController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<BezoekerModel> _userManager;
    private readonly SignInManager<BezoekerModel> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IAccountService _accountService;
    private readonly IUserRedirectionService _redirectionService;

    public BeheerderController(ApplicationDbContext context, UserManager<BezoekerModel> userManager, SignInManager<BezoekerModel> signInManager, RoleManager<IdentityRole> roleManager, IAccountService accountService, IUserRedirectionService redirectionService)
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
    public async Task<IActionResult> IndexUser()
    {
        var users = await _userManager.Users.ToListAsync();
        var usersWithRoles = new List<(BezoekerModel, IList<string>)>();
        var userLockoutStatus = new Dictionary<string, bool>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            usersWithRoles.Add((user, roles));
            var lockoutEndDate = await _userManager.GetLockoutEndDateAsync(user);
            userLockoutStatus[user.Id] = lockoutEndDate.HasValue && lockoutEndDate.Value > DateTimeOffset.Now;
        }

        ViewBag.Users = users;
        ViewBag.Roles = usersWithRoles.ToDictionary(x => x.Item1.Id, x => x.Item2);
        ViewBag.LockoutStatus = userLockoutStatus;
        ViewBag.AllUsersBlocked = userLockoutStatus.Values.All(status => status); // Set the overall status

        return View(users);
    }

    // GET: ItemModels/Delete/5
    public async Task<IActionResult> DeleteItem(int? id)
    {
        if (id == null || _context.Items == null)
        {
            return NotFound();
        }

        var itemModel = await _context.Items
            .Include(i => i.Auteur)
            .Include(i => i.Locatie)
            .FirstOrDefaultAsync(m => m.ID == id);
        if (itemModel == null)
        {
            return NotFound();
        }

        return View(itemModel);
    }

    // POST: ItemModels/Delete/5
    [HttpPost, ActionName("DeleteItemConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteItemConfirmed(int id)
    {
        if (_context.Items == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Items'  is null.");
        }
        var itemModel = await _context.Items.FindAsync(id);
        if (itemModel != null)
        {
            _context.Items.Remove(itemModel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("IndexItem", "Medewerker");
    }

    private bool ItemModelExists(int id)
    {
        return (_context.Items?.Any(e => e.ID == id)).GetValueOrDefault();
    }

    public async Task<IActionResult> DeleteAuthor(int? id)
    {
        if (id == null || _context.Auteurs == null)
        {
            return NotFound();
        }

        var auteurModel = await _context.Auteurs
            .FirstOrDefaultAsync(m => m.ID == id);
        if (auteurModel == null)
        {
            return NotFound();
        }

        return View(auteurModel);
    }

    // POST: AuteurModels/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteAuthorConfirmed(int id)
    {
        if (_context.Auteurs == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Auteurs'  is null.");
        }
        var auteurModel = await _context.Auteurs.FindAsync(id);
        if (auteurModel != null)
        {
            _context.Auteurs.Remove(auteurModel);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction("IndexAuthor", "Medewerker");
    }


    public IActionResult CreateUser()
    {
        try
        {
            var abonnementenList = _context.Abonnementen.ToList();
            var rolesList = _roleManager.Roles.Select(r => r.Name).ToList();
            ViewBag.Abonnementen = new SelectList(abonnementenList, "ID", "Type");
            ViewBag.Roles = new SelectList(rolesList);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateUser(UserViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var abonnement = _context.Abonnementen.Find(model.AbonnementID);
                if (abonnement != null)
                {
                    var user = new BezoekerModel
                    {
                        UserName = model.Email,
                        Email = model.Email,
                        Naam = model.Naam, // Added this line
                        AbonnementID = model.AbonnementID, // Added this line
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, model.Role);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(IndexUser));
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Abonnement ID.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            var abonnementenList = _context.Abonnementen.ToList();
            var rolesList = _roleManager.Roles.Select(r => r.Name).ToList();
            ViewBag.Abonnementen = new SelectList(abonnementenList, "ID", "Type");
            ViewBag.Roles = new SelectList(rolesList);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> ToggleBlockUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user != null)
        {
            var lockoutEndDate = await _userManager.GetLockoutEndDateAsync(user);
            if (lockoutEndDate.HasValue && lockoutEndDate.Value > DateTimeOffset.Now)  // if user is blocked
            {
                await _userManager.SetLockoutEndDateAsync(user, null);  // unblock the user
            }
            else
            {
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);  // block the user
            }

            return RedirectToAction("IndexUser");
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ToggleBlockAllUsers()
    {
        var allUsers = await _userManager.Users.ToListAsync();

        var isAnyUserBlocked = allUsers.Any(user => user.LockoutEnd != null && user.LockoutEnd > DateTimeOffset.Now);

        foreach (var user in allUsers)
        {
            if (isAnyUserBlocked)
            {
                await _userManager.SetLockoutEndDateAsync(user, null); // Unblock all users
            }
            else
            {
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue); // Block all users
            }
        }

        return RedirectToAction("IndexUser");
    }




    [HttpGet]
    public async Task<IActionResult> EditUser(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        // Retrieve user roles and select the first one (assuming a user has only one role)
        var roles = await _userManager.GetRolesAsync(user);
        var role = roles.FirstOrDefault();

        // Retrieve the Abonnement list for the dropdown menu
        var abonnementenList = _context.Abonnementen.ToList();
        ViewBag.Abonnementen = new SelectList(abonnementenList, "ID", "Type");

        // Retrieve the Roles list for the dropdown menu
        var rolesList = await _roleManager.Roles.ToListAsync();
        ViewBag.Roles = new SelectList(rolesList, "Name", "Name");

        var model = new UserViewModel
        {
            Email = user.Email,
            Naam = user.Naam,
            AbonnementID = user.AbonnementID,
            Role = role
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditUser(string id, UserViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Email = model.Email;
            user.Naam = model.Naam;
            user.AbonnementID = model.AbonnementID;

            // Handle password update
            if (!string.IsNullOrEmpty(model.Password))
            {
                // Remove old password
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetResult = await _userManager.ResetPasswordAsync(user, token, model.Password);
                if (!resetResult.Succeeded)
                {
                    foreach (var error in resetResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    // Repopulate ViewBag properties
                    ViewBag.Abonnementen = new SelectList(_context.Abonnementen.ToList(), "ID", "Type");
                    ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");
                    return View(model);
                }
            }

            // Update user info
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                // Update the user's role if it's changed
                var roles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, roles);

                if (!String.IsNullOrEmpty(model.Role))
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                }

                return RedirectToAction("IndexUser");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        // If we got this far, something failed, so redisplay form
        ViewBag.Abonnementen = new SelectList(_context.Abonnementen.ToList(), "ID", "Type");
        ViewBag.Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Name", "Name");

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteUser(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            return RedirectToAction("IndexUser");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        // If we got this far, something failed, so redisplay form
        // Replace 'YourView' with the name of the view you want to display in case of an error
        return View("IndexUser");
    }

    // GET: LocatieModels
    public async Task<IActionResult> IndexLocatie()
    {
        var locaties = await _context.Locaties.ToListAsync();
        return View(locaties);
    }


    
    // GET: LocatieModels/Create
    public IActionResult CreateLocatie()
    {
        return View(new LocatieViewModel());
    }

    // POST: LocatieModels/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateLocatie(LocatieViewModel locatieViewModel)
    {
        if (ModelState.IsValid)
        {
            var locatieModel = new LocatieModel
            {
                Beschrijving = locatieViewModel.Beschrijving
            };

            _context.Add(locatieModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(IndexLocatie));
        }

        return View(locatieViewModel);
    }


    // GET: LocatieModels/Edit/5
    public async Task<IActionResult> EditLocatie(string beschrijving)
    {
        if (string.IsNullOrEmpty(beschrijving) || _context.Locaties == null)
        {
            return NotFound();
        }

        var locatieModel = await _context.Locaties.FirstOrDefaultAsync(l => l.Beschrijving == beschrijving);
        if (locatieModel == null)
        {
            return NotFound();
        }

        var locatieViewModel = new LocatieViewModel
        {
            Beschrijving = locatieModel.Beschrijving
        };

        return View(locatieViewModel);
    }


    // POST: LocatieModels/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditLocatie(LocatieViewModel locatieViewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var locatieModel = await _context.Locaties.FirstOrDefaultAsync(l => l.Beschrijving == locatieViewModel.Beschrijving);
                if (locatieModel == null)
                {
                    return NotFound();
                }

                // Update other properties of locatieModel as needed

                _context.Update(locatieModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception if needed
                throw;
            }
            return RedirectToAction(nameof(IndexLocatie));
        }

        return View(locatieViewModel);
    }


    // GET: LocatieModels/Delete/5
    public async Task<IActionResult> DeleteLocatie(int? id)
    {
        if (id == null || _context.Locaties == null)
        {
            return NotFound();
        }

        var locatieModel = await _context.Locaties
            .Include(l => l.Items) // Include related items
            .FirstOrDefaultAsync(m => m.ID == id);
        if (locatieModel == null)
        {
            return NotFound();
        }

        return View(locatieModel);
    }


    // POST: LocatieModels/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteLocatieConfirmed(int id)
    {
        if (_context.Locaties == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Locaties' is null.");
        }

        var locatieModel = await _context.Locaties.FindAsync(id);
        if (locatieModel == null)
        {
            return NotFound();
        }

        _context.Locaties.Remove(locatieModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(IndexLocatie));
    }






}