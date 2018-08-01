using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeniEmlak.DomainModel;
using YeniEmlak.Models.DomainModel;

namespace YeniEmlak.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            HomeDbContext context = app.ApplicationServices
                .GetRequiredService<HomeDbContext>();
            context.Database.Migrate();
            if (!context.DependentUIs.Any())
            {
                context.DependentUIs.Add(new DependentUI { SelectName = "AdvId", DivId = "kredit", ParentName = "SATILIR" });
                context.DependentUIs.Add(new DependentUI { SelectName = "AdvId", DivId = "sened", ParentName = "SATILIR" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "menzil_nov", ParentName = "Bina ev mənzil" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "mertebe_sayi", ParentName = "Bina ev mənzil" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "mertebe", ParentName = "Bina ev mənzil" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "sahe_m", ParentName = "Bina ev mənzil" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "mertebe_sayi", ParentName = "Həyət evi" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "otaqSayi", ParentName = "Həyət evi" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "sahe_m", ParentName = "Həyət evi" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "sahe_s", ParentName = "Həyət evi" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "sahe_s", ParentName = "Torpaq sahəsi" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "mertebe_sayi", ParentName = "Obyekt" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "mertebe", ParentName = "Obyekt" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "otaqSayi", ParentName = "Obyekt" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "sahe_m", ParentName = "Obyekt" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "sahe_s", ParentName = "Obyekt" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "mertebe_sayi", ParentName = "Ofis" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "mertebe", ParentName = "Ofis" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "otaqSayi", ParentName = "Ofis" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "sahe_m", ParentName = "Ofis" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "sahe_m", ParentName = "Qaraj" });
                context.DependentUIs.Add(new DependentUI { SelectName = "HomeTypes", DivId = "sahe_m", ParentName = "Digər" });
            }

            if (!context.HomeTypes.Any())
            {
                context.HomeTypes.AddRange(
                    new HomeType { Name = "Bina ev mənzil" },
                    new HomeType { Name = "Həyət evi" },
                    new HomeType { Name = "Torpaq sahəsi" },
                    new HomeType { Name = "Obyekt" },
                    new HomeType { Name = "Ofis" },
                    new HomeType { Name = "Qaraj" },
                    new HomeType { Name = "Digər" }

                );
            }
            if (!context.Cities.Any())
            {
                context.Cities.AddRange(
                    new City { Name = "Baki", AreaType = AreaType.City },
                    new City { Name = "Abşeron", AreaType = AreaType.City },
                    new City { Name = "Xırdalan ş.", AreaType = AreaType.City },
                    new City { Name = "Sumqayit", AreaType = AreaType.City },
                    new City { Name = "Gəncə", AreaType = AreaType.City },
                    new City { Name = "Ağdaş", AreaType = AreaType.City },
                    new City { Name = "Ağstafa", AreaType = AreaType.City },
                    new City { Name = "Ağsu", AreaType = AreaType.City },
                    new City { Name = "Astara", AreaType = AreaType.City },
                    new City { Name = "Balakən", AreaType = AreaType.City },
                    new City { Name = "Quba", AreaType = AreaType.City },
                    new City { Name = "Bərdə", AreaType = AreaType.City },
                    new City { Name = "Beyləqan", AreaType = AreaType.City },
                    new City { Name = "Biləsuvar", AreaType = AreaType.City },
                    new City { Name = "Cəbrayıl", AreaType = AreaType.City },
                    new City { Name = "Cəlilabad", AreaType = AreaType.City },
                    new City { Name = "Daşkəsən", AreaType = AreaType.City }
                    );
            }
            if (!context.AdverTypes.Any())
            {
                context.AdverTypes.AddRange(
                    new AdverType { Name = "SATILIR" },
                    new AdverType { Name = "KİRAYƏ AYLIQ" },
                    new AdverType { Name = "KİRAYƏ GÜNLÜK" }
                 );
            }

            if (!context.AdverOwners.Any())
            {
                context.AdverOwners.AddRange(
                    new AdverOwner { Type = "Əmlak sahibi" },
                    new AdverOwner { Type = "Vasitəçi/Rieltor" }
                 );
            }
            context.SaveChanges();
        }
    }
}
