using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;
using YeniEmlak.Models.DomainModel;
using YeniEmlak.Models.Tools;
using YeniEmlak.Models.ViewModel;
using YeniEmlak.ViewModel;

namespace YeniEmlak.Models
{
    public class EFHomeRepository : IHomeRepository
    {
        private HomeDbContext context;

        public EFHomeRepository(HomeDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Home> Homes => context.Homes;
        public IQueryable<AdverOwner> AdverOwners => context.AdverOwners;
        public IQueryable<AdverType> AdverTypes => context.AdverTypes;
        public IQueryable<User> Users => context.Users;
        public IQueryable<City> Cities => context.Cities;
        public IQueryable<PhoneNumber> PhoneNumbers => context.PhoneNumbers;
        public IQueryable<HomeType> HomeTypes => context.HomeTypes;
        public IQueryable<DependentUI> DependentUIs => context.DependentUIs;
        public IQueryable<Equipment> Equipments => context.Equipments;
        public void Create(HomeViewModel vm)
        {
            {
                try
                {
                    if (vm == null)
                    {
                        throw new ArgumentNullException("Home View Model");
                    }
                    if (vm.Image != null)
                    {
                        var fileName = ImageHelpers.GetUniqueName(vm.Image.FileName);
                        vm.HomeImg = fileName;
                        var uploads = $"{@"C:\YeniEmlakImages\"}";
                        var filePath = Path.Combine(uploads, fileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                        {
                            vm.Image.CopyTo(fileStream);
                        }
                    }

                    context.Homes.Add(HomeViewModel.MapHomeViewModelToHome(vm));
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Delete(HomeViewModel vm)
        {
            try
            {
                if (vm == null)
                {
                    throw new ArgumentNullException("Home View Model");
                }
                context.Homes.Remove(HomeViewModel.MapHomeViewModelToHome(vm));
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Home> GetAll()
        {
            try
            {
                return context.Homes.Include(x => x.City).Include(x => x.AdverType).Include(x => x.HomeType).ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<Home> GetByFilterParams(FilteringParams filterParam)
        {
            if (filterParam != null)
            {
                IQueryable<Home> homes = context.Homes;
                if (filterParam.HomeTypeId!=null)
                {
                    homes = context.Homes.Where(x=>x.HomeTypeId==filterParam.HomeTypeId);
                }
                if (filterParam.CityId!=null)
                {
                    homes = homes.Where(x=>x.CityId==filterParam.CityId);
                }
                if (filterParam.AdverTypeId!=null)
                {
                    homes = homes.Where(x=>x.AdverTypeId==filterParam.AdverTypeId);
                }
                if (filterParam.Credit != null)
                {
                    homes = homes.Where(x => x.Credit == filterParam.Credit);
                }
                if (filterParam.Price1!=null)
                {
                    homes = homes.Where(x=>x.Price>=filterParam.Price1);
                }
                if (filterParam.Price2!=null)
                {
                    homes = homes.Where(x=>x.Price<=filterParam.Price2);
                }
                if (filterParam.Area1 != null)
                {
                    homes = homes.Where(x => x.Area >= filterParam.Area1);
                }
                if (filterParam.Area2!=null)
                {
                    homes = homes.Where(x=>x.Area<=filterParam.Area2);
                }

                if (filterParam.RoomCount1 != null)
                {
                    homes = homes.Where(x => x.Area >= filterParam.RoomCount1);
                }
                if (filterParam.RoomCount2 != null)
                {
                    homes = homes.Where(x => x.Area <= filterParam.RoomCount2);
                }
                return homes.Include(x => x.City).Include(x => x.AdverType).Include(x => x.HomeType).ToList();
            }
            throw new Exception("NOT ANY HOME FOUND");


        }

        public void Update(HomeViewModel vm)
        {
            try
            {
                if (vm == null)
                {
                    throw new ArgumentNullException("Home View Model");
                }
                context.Entry(HomeViewModel.MapHomeViewModelToHome(vm)).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
