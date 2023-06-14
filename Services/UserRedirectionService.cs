using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCLibraryApp.Interfaces;
using MVCLibraryApp.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCLibraryApp.Services
{
    public class UserRedirectionService : IUserRedirectionService
    {
        private readonly UserManager<VisitorModel> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRedirectionService(UserManager<VisitorModel> userManager, IHttpContextAccessor httpContextAccessor)
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

                    if (roles.Contains("Visitor") && !currentRoute.Value.Contains("Visitor/Dashboard"))
                    {
                        return new RedirectToActionResult("Dashboard", "Visitor", null);
                    }
                    else if (roles.Contains("Employee") && !currentRoute.Value.Contains("Employee/Dashboard"))
                    {
                        return new RedirectToActionResult("Dashboard", "Employee", null);
                    }
                    else if (roles.Contains("Admin") && !currentRoute.Value.Contains("Admin/Dashboard"))
                    {
                        return new RedirectToActionResult("Dashboard", "Admin", null);
                    }
                }
            }

            return null;
        }
    }
}
