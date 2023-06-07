using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCLibraryApp.Models;

[Authorize(Roles = "Beheerder")]
public class BeheerderController : Controller
{

    private List<BezoekerModel> bezoekers = new List<BezoekerModel>();
    public IActionResult Dashboard()
    {
        ViewBag.Bezoekers = bezoekers;
        return View();
    }
}