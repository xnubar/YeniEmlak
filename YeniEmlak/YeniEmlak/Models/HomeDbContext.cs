using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;
using YeniEmlak.Models.DomainModel;

namespace YeniEmlak.Models
{
    public class HomeDbContext:DbContext
    {

        public HomeDbContext(DbContextOptions<HomeDbContext> options):base(options)
        {     }
        public DbSet<Home> Homes { get; set; }
        public DbSet<AdverType> AdverTypes { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<HomeType> HomeTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<DependentUI> DependentUIs { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        public class ApplicationDbContextFactory
         : IDesignTimeDbContextFactory<HomeDbContext>
        {

            public HomeDbContext CreateDbContext(string[] args) =>
                Program.BuildWebHost(args).Services
                    .GetRequiredService<HomeDbContext>();
        }
     
    }
}
