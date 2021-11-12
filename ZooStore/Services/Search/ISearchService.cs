using System.Collections.Generic;
using System.Text;
using ZooStore.Models;

namespace ZooStore.Services.Search
{
    public interface ISearchService
    {
        public IEnumerable<Product> GetSerchedProducts(IEnumerable<Product> products, string search);

    }

}
