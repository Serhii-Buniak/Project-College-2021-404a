using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZooStore.Controllers.Extensions;
using ZooStore.Models;

namespace ZooStore.Services.Search
{
    public partial class SearchService : ISearchService
    {
        public IEnumerable<Product> GetSerchedProducts(IEnumerable<Product> products, string searchText)
        {
            HashSet<ProductAndPriority?> productsSet = new();

            foreach (Product product in products)
            {
                ProductAndPriority? productPriority = TryGetProductAndPriority(product, GetInfoToFind(product), searchText);
                if (productPriority is not null)
                {
                    productsSet.Add(productPriority);
                }
            }

            return productsSet.OrderBy(p => p.Value.Priority).Select(p => p.Value.Product);
        }


        private ProductAndPriority? TryGetProductAndPriority(Product product, IEnumerable<string> valuesToFind, string searchText)
        {
            ProductAndPriority? productPriority = null;

            string[] toFind = valuesToFind.ToArray();
            for (int i = 0; i < toFind.Length; i++)
            {
                productPriority = TryMakeProductAndPriority(product, priority: i + 1, toFind[i], searchText);
                if (productPriority is not null)
                    return productPriority;

                string[] searchWords = searchText.Split(' ')
                                        .Where(s => string.IsNullOrWhiteSpace(s))
                                        .Select(s => s.Trim(' ', '.', '/', '*', ','))
                                        .ToArray();

                for (int j = 0; j < searchWords.Length; j++)
                {
                    productPriority = TryMakeProductAndPriority(product, priority: i * j * 2 + 1, toFind[i], searchWords[j]);
                    if (productPriority is not null)
                        return productPriority;
                }


            }

            return productPriority;
        }
        private ProductAndPriority? TryMakeProductAndPriority(Product product, int priority, string valueToFind, string searchText)
        {
            ProductAndPriority? productPriority = null;

            if (valueToFind.Contains(searchText, StringComparison.OrdinalIgnoreCase))
            {
                productPriority = new ProductAndPriority()
                {
                    Product = product,
                    Priority = priority
                };
            }

            return productPriority;
        }

        private IEnumerable<string> GetInfoToFind(Product product)
        {
            return new string[]
            {
                product.Name,
                product.Description,
                GetStringValues(product.Properties)
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
