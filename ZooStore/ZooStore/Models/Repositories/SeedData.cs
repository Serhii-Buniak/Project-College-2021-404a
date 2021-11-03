using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{

    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
      .GetRequiredService<StoreDbContext>();
            ApplicationDbContext context2 = app.ApplicationServices
     .GetRequiredService<ApplicationDbContext>();

            //context.Categories.AddRange(new Category[]
            //{
            //    new Category{ Name = "Їжа для кіщок"},
            //    new Category{ Name = "Їжа для кіщок"},
            //    new Category{ Name = "Їжа для кіщок"},
            //    new Category{ Name = "Їжа для кіщок"},
            //    new Category{ Name = "Їжа для кіщок"},
            //    new Category{ Name = "Їжа для кіщок"},
            //    new Category{ Name = "Їжа для кіщок"},
            //    new Category{ Name = "Їжа для кіщок"},
            //    new Category{ Name = "Їжа для кіщок"},
            //    new Category{ Name = "Їжа для кіщок"},
            //    new Category{ Name = "Їжа для кіщок"},
            //});
            //context.SaveChanges();

            //if (!context.Animals.Any())
            //{
            //    context.Animals.AddRange(
            //        new Animal { Name = "Собака", Price = 40, Description = "Хороший дуже!!!", BirthDay = new DateTime(2019, 5, 20), Species = "Бульдог", ImagePath = "/img/products/1280px-Racibórz_2007_082.jpg" }
            //        );
            //    context.SaveChanges();
            //}

            //if (!context.Accessories.Any())
            //{
            //    context.Accessories.AddRange(
            //        new Accessory { Name = "Клітка для папугая", Price = 40, Description = "Велика дуже!!!", Weight = 3, Material = "Метал", Color = "Білий", Guarantee = 2, Country = "Україна", Producer = "УкрЗалізниця", ImagePath = "/img/products/26706651.jpg" }
            //        );
            //    context.SaveChanges();
            //}
        }
    }
}