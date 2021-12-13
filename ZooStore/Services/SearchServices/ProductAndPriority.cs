using ZooStore.Models;

namespace ZooStore.Services.SearchServices
{
    public partial class SearchService
    {
        private class ProductAndPriority
        {
            public Product Product { get; init; }
            public int Priority { get; private set; } = 0;
            public override int GetHashCode()
            {
                return Product.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                Product product = ((ProductAndPriority)obj).Product;
                return Product.Equals(product);
            }
            public ProductAndPriority Increment(int value = 1)
            {
                Priority += value;
                return this;
            }
        }
    }

}
