using System.Collections.Generic;
using ZooStore.Models;

namespace ZooStore.Comparers
{
    public class ProductComparerByPriceAscending : IComparer<Product>
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Price > p2.Price)
                return 1;
            else if (p1.Price < p2.Price)
                return -1;
            else
                return 0;
        }
    }
    public class ProductComparerByPriceDescending : IComparer<Product>
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Price < p2.Price)
                return 1;
            else if (p1.Price > p2.Price)
                return -1;
            else
                return 0;
        }
    }
}
