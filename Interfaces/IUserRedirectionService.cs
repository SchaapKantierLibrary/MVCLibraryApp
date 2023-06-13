using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;


namespace MVCLibraryApp.Interfaces
{
    public interface IUserRedirectionService
    {
        Task<IActionResult> GetRedirectBasedOnRole(ClaimsPrincipal userPrincipal);
    }
}
