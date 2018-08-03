using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;
using YeniEmlak.Models.ViewModel;

namespace YeniEmlak.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void Create(UserViewModel vm);
        void Update(UserViewModel vm);
        void Delete(UserViewModel vm);
    }
}
