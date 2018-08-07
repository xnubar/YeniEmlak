using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YeniEmlak.Models;
using YeniEmlak.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using YeniEmlak.DomainModel;

namespace YeniEmlak
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HomeDbContext>(options =>
options.UseSqlServer(Configuration["Data:YeniEmlak:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options =>
options.UseSqlServer(Configuration["Data:UserIdentity:ConnectionString"]));
            services.AddIdentity<User, IdentityRole>()
 .AddEntityFrameworkStores<AppIdentityDbContext>()
 .AddDefaultTokenProviders();
            services.AddTransient<IHomeRepository, EFHomeRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseAuthentication();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "Account", template: "{controller=Account}/{action=Index}/{id?}");
                routes.MapRoute(name: "Admin", template: "{controller=Admin}/{action=Index}/{id?}");

            });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
