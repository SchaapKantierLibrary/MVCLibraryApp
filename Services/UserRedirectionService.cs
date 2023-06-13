using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCLibraryApp.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCLibraryApp.Services
{
    public class UserRedirectionService
    {
        private readonly UserManager<BezoekerModel> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRedirectionService(UserManager<BezoekerModel> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> GetRedirectBasedOnRole(ClaimsPrincipal userPrincipal)
        {
            if (userPrincipal.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(userPrincipal);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var currentRoute = _httpContextAccessor.HttpContext.Request.Path;

                    if (roles.Contains("Bezoeker") && !currentRoute.Value.Contains("Bezoeker/Dashboard"))
                    {
                        return new RedirectToActionResult("Dashboard", "Bezoeker", null);
                    }
                    else if (roles.Contains("Medewerker") && !currentRoute.Value.Contains("Medewerker/Dashboard"))
                    {
                        return new RedirectToActionResult("Dashboard", "Medewerker", null);
                    }
                    else if (roles.Contains("Beheerder") && !currentRoute.Value.Contains("Beheerder/Dashboard"))
                    {
                        return new RedirectToActionResult("Dashboard", "Beheerder", null);
                    }
                }
            }

            return null;
        }
    }
}
