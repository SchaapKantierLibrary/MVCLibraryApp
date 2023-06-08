using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;

[Authorize(Roles = "Beheerder")]
public class BeheerderController : Controller
{
    private readonly UserManager<BezoekerModel> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public BeheerderController(UserManager<BezoekerModel> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
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

    private SelectList GetRoles()
    {
        var roles = _roleManager.Roles.Select(r => r.Name).ToList();
        return new SelectList(roles);
    }

    [AllowAnonymous]
    public IActionResult Create()
    {
        ViewBag.Roles = GetRoles(); // Pass the available roles to the view

        var model = new RegisterModel
        {
            SelectedRole = "Bezoeker" // Set the default selected role
        };

        return View(model);
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RegisterModel model, string selectedRole)
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
                if (!string.IsNullOrEmpty(selectedRole))
                {
                    // Assign the selected role to the user
                    await _userManager.AddToRoleAsync(user, selectedRole);
                }
                return RedirectToAction("Dashboard");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        // If registration fails, return to the registration view with the model
        ViewBag.Roles = GetRoles(); // Pass the available roles to the view
        return View(model);
    }
}