using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace ZooStore.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public Guid? SubcategoryId { get; set; }
        public SelectList SubcategoriesList { get; set; }
        public SelectList ComparersList { get; set; }
        public string SearchText { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string Comparer { get; set; }
    }
}
