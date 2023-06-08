using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Models;

[Authorize(Roles = "Beheerder")]
public class BeheerderController : Controller
{
    private UserManager<BezoekerModel> userManager;
    public BeheerderController(UserManager<BezoekerModel> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<IActionResult> Dashboard()
    {
        ViewBag.Bezoekers = await userManager.Users.ToListAsync();
        return View();
    }
}