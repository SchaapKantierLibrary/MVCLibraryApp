using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Interfaces;
using MVCLibraryApp.Models;
using MVCLibraryApp.ViewModels;


[Authorize(Roles = "Beheerder")]
public class BeheerderController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<BezoekerModel> _userManager;
    private readonly SignInManager<BezoekerModel> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IAccountService _accountService;

    public BeheerderController(ApplicationDbContext context, UserManager<BezoekerModel> userManager, SignInManager<BezoekerModel> signInManager, RoleManager<IdentityRole> roleManager, IAccountService accountService)
    {
        _accountService = accountService;
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }


    public async Task<IActionResult> Dashboard()
    {
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
            userLockoutStatus.Add(user.Id, lockoutEndDate.HasValue && lockoutEndDate.Value > DateTimeOffset.Now);
        }

        ViewBag.Users = users;
        ViewBag.Roles = usersWithRoles.ToDictionary(x => x.Item1.Id, x => x.Item2);
        ViewBag.LockoutStatus = userLockoutStatus;

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



}