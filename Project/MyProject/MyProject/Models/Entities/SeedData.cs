using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;
using System;

namespace MyProject.Models.Entities
{

    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                .GetRequiredService<StoreDbContext>();

            context.Database.Migrate();
            if (!context.Foods.Any())
            {

                context.Foods.AddRange(
                    new Food { Name = "БУЛОЧКА", Price = 40, Description = "Вкусно дуже ням ням", Weight = 5, Producer = "Kitten", Country = "Франція" }
                    );
                context.SaveChanges();
            }

            if (!context.Animals.Any())
            {
                context.Animals.AddRange(
                    new Animal { Name = "Собака", Price = 40, Description = "Хороший дуже!!!", BirthDay = new DateTime(2019, 5, 20), Species = "Бульдог"}
                    );
                context.SaveChanges();
            }

            if (!context.Accessories.Any())
            {
                context.Accessories.AddRange(
                    new Accessory { Name = "Клітка для папугая", Price = 40, Description = "Велика дуже!!!", Weight = 3, Material = "Метал", Color = "Білий", Guarantee = 2, Country = "Україна", Producer = "УкрЗалізниця"}
                    );
                context.SaveChanges();
            }
        }
    }
}