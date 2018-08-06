﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YeniEmlak.DomainModel;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace YeniEmlak.Models.ViewModel
{
    public class AppIdentityDbContext:IdentityDbContext<User>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext>options):base(options)
        {

        }
        public class ApplicationDbContextFactory
         : IDesignTimeDbContextFactory<AppIdentityDbContext>
        {

            public AppIdentityDbContext CreateDbContext(string[] args) =>
                Program.BuildWebHost(args).Services
                    .GetRequiredService<AppIdentityDbContext>();
        }
        ////public static async Task CreateAdminAccount(IServiceProvider serviceProvider,
        ////    IConfiguration configuration) {

        ////    UserManager<User> userManager =
        ////        serviceProvider.GetRequiredService<UserManager<User>>();
        ////    RoleManager<IdentityRole> roleManager =
        ////        serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        ////    string username = configuration["Data:AdminUser:Name"];
        ////    string email = configuration["Data:AdminUser:Email"];
        ////    string password = configuration["Data:AdminUser:Password"];
        ////    string role = configuration["Data:AdminUser:Role"];

        ////    if (await userManager.FindByNameAsync(username) == null) {
        ////        if (await roleManager.FindByNameAsync(role) == null) {
        ////            await roleManager.CreateAsync(new IdentityRole(role));
        ////        }

        ////        User user = new AppUser {
        ////            UserName = username,
        ////            Email = email
        ////        };

        ////        IdentityResult result = await userManager
        ////            .CreateAsync(user, password);
        ////        if (result.Succeeded) {
        ////            await userManager.AddToRoleAsync(user, role);
        ////        }
        ////    }
        ////}
    }
}
