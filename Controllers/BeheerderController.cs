using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Beheerder")]
public class BeheerderController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }
}