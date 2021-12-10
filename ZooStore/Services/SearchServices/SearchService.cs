using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZooStore.Models;

namespace ZooStore.Services.SearchServices
{
    public partial class SearchService : ISearchService
    {
        public IEnumerable<Product> GetSerchedProducts(IEnumerable<Product> products, string searchText)
        {
            List<ProductAndPriority> productsSet = new();

            foreach (Product product in products)
            {
                ProductAndPriority productPriority = TryGetProductAndPriority(product, GetInfoToFind(product), searchText);
                if (productPriority is not null)
                {
                    productsSet.Add(productPriority);
                }
            }

            return productsSet.Where(p => p.Priority != 0).OrderByDescending(p => p.Priority).Select(p => p.Product);
        }


        private ProductAndPriority TryGetProductAndPriority(Product product, IEnumerable<string> valuesToFind, string searchText)
        {
            ProductAndPriority productPriority = new() { Product = product };

            string[] toFind = valuesToFind.ToArray();

            string[] searchWords = searchText.Split(' ')
                        .Select(s => s.Trim(' ', '.', '/', '*', ',', '+'))
                        .Where(s => string.IsNullOrWhiteSpace(s) == false)
                        .ToArray();

            for (int i = 0; i < toFind.Length; i++)
            {
                TryIncrement(productPriority, toFind[i], searchText, (i + 1) * 5);


                for (int j = 0; j < searchWords.Length; j++)
                {
                    TryIncrement(productPriority, toFind[i], searchWords[j], i * 3 + 1);
                }
            }

            return productPriority;
        }


        private ProductAndPriority TryIncrement(ProductAndPriority productPriority, string valueToFind, string searchText, int value)
        {
            if (valueToFind.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            {
                productPriority.Increment(value);
            }
            return productPriority;
        }

        private IEnumerable<string> GetInfoToFind(Product product)
        {
            return new string[]
            {
                product.Description,
                GetStringValues(product.Properties),
                product.Name,
            };
        }

        private string GetStringValues(IEnumerable<Property> propertyies)
        {
            StringBuilder values = new("");
            foreach (Property property in propertyies)
            {
                values.Append(property.Value + " ");
            }
            return values.ToString();
        }
    }

}
