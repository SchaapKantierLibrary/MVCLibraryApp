using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MVCLibraryApp.Models;

namespace MVCLibraryApp.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUser(RegisterModel model);
        Task<SignInResult> LoginUser(LoginModel model);
        Task LogoutUser();
        Task<VisitorModel> GetUser(ClaimsPrincipal user);
    }

}
