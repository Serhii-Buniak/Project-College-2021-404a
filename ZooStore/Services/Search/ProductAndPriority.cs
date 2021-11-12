using ZooStore.Models;

namespace ZooStore.Services.Search
{
    public partial class SearchService
    {
        private struct ProductAndPriority
        {
            public Product Product { get; init; }
            public int Priority { get; init; }
            public override int GetHashCode()
            {
                return Product.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                Product product = ((ProductAndPriority)obj).Product;
                return Product.Equals(product);
            }
        }
    }

}
