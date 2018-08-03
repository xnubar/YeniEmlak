using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;
using YeniEmlak.Models.ViewModel;

namespace YeniEmlak.Models
{
    public class EFUserRepository : IUserRepository
    {
        private AppIdentityDbContext context;
        public EFUserRepository(AppIdentityDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<User> Users => context.Users;

        public void Create(UserViewModel vm)
        {
            
        }

        public void Delete(UserViewModel vm)
        {
            
        }

        public void Update(UserViewModel vm)
        {
            
        }
    }
}
