using Microsoft.AspNetCore.Identity;
using RawMaterials.ExceptionsManagement.Exceptions;
using RawMaterials.Models.Dto.User;
using RawMaterials.Models.Entities;
using RawMaterials.Models.IO.ResponseModels.User;
using RawMaterials.Service.IService.UserServices;
using System.Threading.Tasks;

namespace RawMaterials.Service.UserServices
{
    public class LoginService : ILoginService
    {
        SignInManager<User> _signInManager;
        UserManager<User> _userManager;
        public LoginService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<LoginResponseModel> Login(LoginDto loginDto)
        {

            User RequesterUser = null;

            // fetch either username or email
            if (loginDto.UserName != null)
                RequesterUser = await _userManager.FindByNameAsync(loginDto.UserName);

            if (loginDto.Email != null)
                RequesterUser = await _userManager.FindByEmailAsync(loginDto.Email);

            if (RequesterUser == null)
                throw new LoginNotValidException();

            // sign user in
            await _signInManager.SignOutAsync();
            SignInResult result = await _signInManager.PasswordSignInAsync(RequesterUser, loginDto.Password, false, false);

            return new LoginResponseModel(result.Succeeded, result.ToString());

        }
    }
}
