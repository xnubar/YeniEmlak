using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using YeniEmlak.DomainModel;

namespace YeniEmlak.Models
{
    public class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Password123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            var RoleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<User> userManager = app.ApplicationServices
            .GetRequiredService<UserManager<User>>();
            string[] roles = { "Admin", "User" };
            foreach (var roleName in roles)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            User user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new User { UserName = "Admin", Email = "admin.admin@gmail.com" };
                await userManager.CreateAsync(user, adminPassword);
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}

