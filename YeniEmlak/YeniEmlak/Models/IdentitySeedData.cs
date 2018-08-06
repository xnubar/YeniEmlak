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
    //public class IdentitySeedData
    //{
    //    private const string adminUser = "Admin";
    //    private const string adminPassword = "Password123$";
    //    public static async void EnsurePopulated(IApplicationBuilder app)
    //    {
    //        UserManager<User> userManager = app.ApplicationServices
    //        .GetRequiredService<UserManager<User>>();
    //        IdentityUser user = await userManager.FindByIdAsync(adminUser);
    //        if (user == null)
    //        {
    //            user = new User { Name = "Admin" };
    //            await userManager.CreateAsync(user,adminPassword);
    //        }
    //    }
    //}
}
