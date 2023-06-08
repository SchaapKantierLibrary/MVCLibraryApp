using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;

[Authorize(Roles = "Beheerder")]
public class BeheerderController : Controller
{
    private readonly UserManager<BezoekerModel> _userManager;

    public BeheerderController(UserManager<BezoekerModel> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Dashboard()
    {
        var users = await _userManager.Users.ToListAsync();
        var usersWithRoles = new List<(BezoekerModel, IList<string>)>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            usersWithRoles.Add((user, roles));
        }

        ViewBag.Bezoekers = users;
        ViewBag.Rol = usersWithRoles.ToDictionary(x => x.Item1.Id, x => x.Item2);

        return View(users);
    }

    [AllowAnonymous]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RegisterModel model)
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
}