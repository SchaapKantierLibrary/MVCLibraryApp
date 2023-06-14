using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MVCLibraryApp.Models;
using MVCLibraryApp.Interfaces;

namespace MVCLibraryApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<VisitorModel> _userManager;
        private readonly SignInManager<VisitorModel> _signInManager;

        public AccountService(UserManager<VisitorModel> userManager, SignInManager<VisitorModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUser(RegisterModel model)
        {
            var user = new VisitorModel
            {
                UserName = model.Email,
                Email = model.Email,
                Name = model.Name,
                AbonnementID = 1
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Adding the user to the 'Visitor' role
                await _userManager.AddToRoleAsync(user, "Visitor");
                await _signInManager.SignInAsync(user, isPersistent: false); // Log in the user
            }
            return result;
        }

        public async Task<SignInResult> LoginUser(LoginModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
        }

        public async Task LogoutUser()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<VisitorModel> GetUser(ClaimsPrincipal user)
        {
            return await _userManager.GetUserAsync(user);
        }
    }

}
