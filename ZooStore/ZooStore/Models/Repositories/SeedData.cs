using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using ZooStore.Data;
using System.Collections.Generic;

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
            context.Database.Migrate();

            //context.Categories.Add(new Category { Name = "Їжа" });
            //context.Categories.Add(new Category { Name = "Аксесуари" });
            //context.Categories.Add(new Category { Name = "Тварини" });
            //context.SaveChanges();

            //context.Subcategories.Add(new Subcategory { Name = "Їжа для собак", Category = context.Categories.First(c => c.Name == "Їжа")});
            //context.Subcategories.Add(new Subcategory { Name = "Їжа для гризунів", Category = context.Categories.First(c => c.Name == "Їжа") });
            //context.Subcategories.Add(new Subcategory { Name = "Їжа для риб", Category = context.Categories.First(c => c.Name == "Їжа") });

            //context.Subcategories.Add(new Subcategory { Name = "Акваріуми", Category = context.Categories.First(c => c.Name == "Аксесуари") });
            //context.Subcategories.Add(new Subcategory { Name = "Клітки для гризунів", Category = context.Categories.First(c => c.Name == "Аксесуари") });
            //context.Subcategories.Add(new Subcategory { Name = "Будиночки для соак і кішобк", Category = context.Categories.First(c => c.Name == "Аксесуари") });
            //context.Subcategories.Add(new Subcategory { Name = "Годівниці для собак і кішок", Category = context.Categories.First(c => c.Name == "Аксесуари") });
            //context.Subcategories.Add(new Subcategory { Name = "Миски для собак і кішок", Category = context.Categories.First(c => c.Name == "Аксесуари") });

            //context.Subcategories.Add(new Subcategory { Name = "Кішки", Category = context.Categories.First(c => c.Name == "Тварини") });
            //context.Subcategories.Add(new Subcategory { Name = "Гризуни", Category = context.Categories.First(c => c.Name == "Тварини") });
            //context.Subcategories.Add(new Subcategory { Name = "Рибки", Category = context.Categories.First(c => c.Name == "Тварини") });
            //context.Subcategories.Add(new Subcategory { Name = "Папуги", Category = context.Categories.First(c => c.Name == "Тварини") });

            //context.Subcategories.Add(new Subcategory { Name = "Їжа для кішок", Category = context.Categories.First(c => c.Name == "Їжа")});
            //context.SaveChanges();
            //context.Products.Add(new Product()
            //{
            //    Name = "1FSDGJS:LKGJFS1",
            //    Price = 21312,
            //    Description = "fцdsfsdwejrpoewqjrlnfvs;fgweiorhweonjk.hveownwrwe rw",
            //    Subcategory = context.Subcategories.First(s => s.Name == "Їжа для кішок"),
            //    Properties = new List<Property>()
            //    {
            //            new Property() { Key = "Країна", Value = "Україна"},
            //            new Property() { Key = "Маса", Value = "10кг"},
            //            new Property() { Key = "Виробник", Value = "KittyCat"},
            //            new Property() { Key = "Термін придатності", Value = "2 роки"},
            //    }
            //});
            //context.SaveChanges();

            //context.Products.Add(new Product()
            //{
            //    Name = "2FSDGJS:LKGJFS2",
            //    Price = 21312,
            //    Description = "fцdsfsdwejrpoewqjrlnfvs;fgweiorhweonjk.hveownwrwe rw",
            //    Subcategory = context.Subcategories.First(c => c.Name == "Корм для кішок"),
            //    Properties = new List<Property>()
            //    {
            //        new Property() { Key = "Країна", Value = "Україна"},
            //        new Property() { Key = "Термін придатності", Value = "2 роки"},
            //    }
            //});

            context.SaveChanges();
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