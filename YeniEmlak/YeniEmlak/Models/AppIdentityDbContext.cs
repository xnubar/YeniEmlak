using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YeniEmlak.DomainModel;

namespace YeniEmlak.Models.ViewModel
{
    public class AppIdentityDbContext:IdentityDbContext<User>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext>options):base(options)
        {

        }
    }
}
