using Extensions.Hosting.AsyncInitialization;
using Microsoft.AspNetCore.Identity;
using RawMaterials.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawMaterials.Initializers.DataInitializers
{
    public class RoleInitializers : IAsyncInitializer
    {
        RoleManager<IdentityRole> _roleManager;
        public RoleInitializers(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task InitializeAsync()
        {
            List<string> roles = new List<string>
            {
                SystemRoles.IMPORTER.ToString(),
                SystemRoles.SUPLIER.ToString(),
                SystemRoles.TEAMWORK.ToString(),
                SystemRoles.SUPERADMIN.ToString()
            };
            var x = await _roleManager.FindByNameAsync(roles[0]);
            if  (x != null)
                return;

            foreach (string role in roles)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(role));
                if (!result.Succeeded)
                    throw new Exception($"can't initialize role {role} at  Application Inatiate, errors: \n" +
                        $"{result.Errors.Select(er => er.Description)}");
            }

        }
    }
}
