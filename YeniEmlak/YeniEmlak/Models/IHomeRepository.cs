﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;
using YeniEmlak.Models.DomainModel;
using YeniEmlak.Models.ViewModel;
using YeniEmlak.ViewModel;

namespace YeniEmlak.Models
{
    public interface IHomeRepository
    {
        IQueryable<Home> Homes { get; }
        IQueryable<AdverType> AdverTypes { get; }
        IQueryable<City> Cities { get; }
        IQueryable<PhoneNumber> PhoneNumbers { get; }
        IQueryable<HomeType> HomeTypes { get; }
        IQueryable<DependentUI> DependentUIs { get; }
        IQueryable<Equipment> Equipments { get; }
        void Create(Home vm);
        void Update(Home vm);
        void Delete(Home vm);
        Home FindById(int id);
        List<Home> GetAll();
        List<Home> GetByFilterParams(FilteringParams filterParam);
    }
}
