using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooStore.Data;

namespace ZooStore.Models.Repositories
{
    public class EFCartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public EFCartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Product product, AppUser user)
        {
            CartDetails cartDetails = new() { Product = product };
            user.Cart.CartDetails.Add(cartDetails);
            _context.SaveChanges();
        }

        public void Remove(Product product, AppUser user)
        {
            ICollection<CartDetails> cartDetailsCollection = GetCartDetailsCollection(user);
            CartDetails cartDetails = GetCartDetails(product, cartDetailsCollection);

            cartDetailsCollection.Remove(cartDetails);
            _context.SaveChanges();
        }

        public bool Contains(Product product, AppUser user)
        {
            var CartDetailsCollection = GetCartDetailsCollection(user);
            if (CartDetailsCollection.Any())
            {
                return CartDetailsCollection.Any(c => c.Product.Id == product.Id);
            }
            else
            {
                return false;
            }
        }

        private ICollection<CartDetails> GetCartDetailsCollection(AppUser user)
        {
            return user.Cart.CartDetails;
        }

        private CartDetails GetCartDetails(Product product, ICollection<CartDetails> cartDetailsCollection)
        {
            return cartDetailsCollection.FirstOrDefault(c => c.Product.Id == product.Id);
        }
    }
}
