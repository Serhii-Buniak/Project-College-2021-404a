using System.Collections.Generic;
using ZooStore.Models;

namespace ZooStore.Services.CartServices
{
    public interface ICartService
    {
        void Add(Product product);
        void Remove(Product product);
        bool Contains(Product product);
        void AddOrRemove(Product product);
        decimal ComputeTotalValue();

        
    }
}
