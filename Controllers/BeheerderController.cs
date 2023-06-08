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
}