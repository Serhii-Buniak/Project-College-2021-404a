using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooStore.Models.ViewModels
{
    public class GroupedCategories
    {
        public IEnumerable<Category> AnimalsCategories { get; set; }
        public IEnumerable<Category> FoodsCategories { get; set; }
        public IEnumerable<Category> AccessoriesCategories { get; set; }
    }
}
