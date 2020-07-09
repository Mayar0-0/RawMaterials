using Extensions.Hosting.AsyncInitialization;
using Microsoft.AspNetCore.Identity;
using RawMaterials.ExceptionsManagement;
using RawMaterials.Models.Entities;
using RawMaterials.Shared.Enumerations;
using System;
using System.Threading.Tasks;

namespace RawMaterials.Initializers.DataInitializers
{
    public class AdminsInitializers : IAsyncInitializer
    {
        UserManager<User> _userManager;
        public AdminsInitializers(UserManager<User> userManger)
        {
            _userManager = userManger;
        }
        public async Task InitializeAsync()
        {
            if (await _userManager.FindByNameAsync("superadmin") != null)
                return;


                User superAdmin = new User()
                {
                    Active = true,
                    UserName = "superadmin",
                    Email = "superadmin@gmail.com",
                    BirthDate = new DateTime(2000, 1, 1),
                    FirstName = "superadmin",
                    LastName = "superadmin",
                    Gender = 'M'
                };

            IdentityResult result = await _userManager.CreateAsync(superAdmin, "P@$$w0rd");

            if (!result.Succeeded)
                throw new UserRegistrationException(result.Errors.ToString());

            await _userManager.AddToRoleAsync(superAdmin, "superadmin");

        }
    }
}
