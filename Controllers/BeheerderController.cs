using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCLibraryApp.Interfaces;
using MVCLibraryApp.Models;


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


}