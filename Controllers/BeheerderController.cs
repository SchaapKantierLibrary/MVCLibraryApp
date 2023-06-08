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

    public async Task<IActionResult> Edit(string id)
    {
        var bezoeker = await _userManager.FindByIdAsync(id);
        var userRoles = await _userManager.GetRolesAsync(bezoeker);

        // Get all available roles
        var roles = await _roleManager.Roles.ToListAsync();

        // Create a SelectList with roles
        var roleList = new SelectList(roles, "Name", "Name");

        // Set the selected role for the user
        ViewBag.Roles = roleList;
        ViewBag.SelectedRole = userRoles.FirstOrDefault();

        return View(bezoeker);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(BezoekerModel bezoeker, string selectedRole)
    {
        if (ModelState.IsValid)
        {
            // Update the user's properties
            var result = await _userManager.UpdateAsync(bezoeker);
            if (result.Succeeded)
            {
                // Retrieve the user's current roles
                var userRoles = await _userManager.GetRolesAsync(bezoeker);

                // Remove the user from all current roles
                await _userManager.RemoveFromRolesAsync(bezoeker, userRoles);

                // Add the user to the selected role
                await _userManager.AddToRoleAsync(bezoeker, selectedRole);

                return RedirectToAction("Dashboard");
            }

            // If the update fails, redisplay the form with the model
            ModelState.AddModelError(string.Empty, "Failed to update the user.");
        }

        // If the model state is invalid, redisplay the form with the model
        return View(bezoeker);
    }

}