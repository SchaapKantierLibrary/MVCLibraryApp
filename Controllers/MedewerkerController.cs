using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCLibraryApp.Controllers
{

    [Authorize(Roles = "Medewerker")]
    public class MedewerkerController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
