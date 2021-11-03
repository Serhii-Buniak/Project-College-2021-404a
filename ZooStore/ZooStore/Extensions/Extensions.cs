using System;
using System.Collections.Generic;
using System.Linq;
using ZooStore.Models;

namespace ZooStore.Controllers.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<Category> GetCategoriesForType(this IEnumerable<Product> products, Type modelType)
        {
            return products.Where(p => p.GetType() == modelType).Select(p => p.Category);
        }
    }
}