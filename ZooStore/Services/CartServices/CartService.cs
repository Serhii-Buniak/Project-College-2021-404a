using ZooStore.Models;
using System.Linq;

namespace ZooStore.Services.CartServices
{
    public class CartService : ICartService
    {
        private readonly Cart _cart;

        public CartService(Cart cart)
        {
            _cart = cart;
        }

        public void Add(Product product)
        {
            _cart.Products.Add(product);
        }

        public void Remove(Product product)
        {
            _cart.Products.Remove(product);
        }

        public bool Contains(Product product)
        {
            return _cart.Products.Contains(product);
        }

        public void AddOrRemove(Product product)
        {
            if (Contains(product))
                Remove(product);
            else
                Add(product);
        }

        public decimal ComputeTotalValue()
        {
            return _cart.Products.Sum(p => p.Price);
        }
    }
}
