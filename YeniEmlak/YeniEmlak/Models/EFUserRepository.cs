using Microsoft.EntityFrameworkCore;
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
            try
            {
                if (vm == null)
                {
                    throw new ArgumentNullException("Home View Model");
                }
                context.Users.Add(UserViewModel.MapUserViewModelToUser(vm));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(UserViewModel vm)
        {
            try
            {
                if (vm == null)
                {
                    throw new ArgumentNullException("User View Model");
                }
                context.Users.Remove(UserViewModel.MapUserViewModelToUser(vm));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(UserViewModel vm)
        {
            try
            {
                if (vm == null)
                {
                    throw new ArgumentNullException("Home View Model");
                }
                context.Entry(UserViewModel.MapUserViewModelToUser(vm)).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
