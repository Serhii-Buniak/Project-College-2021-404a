using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using ZooStore.Comparers;
using ZooStore.Models;
using ZooStore.Models.Repositories;
using ZooStore.Models.ViewModels;
using ZooStore.Services.Search;

namespace ZooStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReadOnlyRepository<Category> _categoryRepository;
        private readonly IReadOnlyRepository<Subcategory> _subcategoryRepository;
        private readonly IReadOnlyRepository<Product> _productRepository;

        private readonly ISearchService _searchService;

        private readonly static IDictionary<string, IComparer<Product>> _productComparers = new Dictionary<string, IComparer<Product>>()
        {
            ["Від дорогих до дешевих"] = new PeopleComparerByPriceDescending(),
            ["Від дешевих до дорогих"] = new PeopleComparerByPriceAscending(),
        };

        public const int pageSize = 1;
        public HomeController(ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository, IProductRepository productRepository, ISearchService searchService)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _productRepository = productRepository;
            _searchService = searchService;
        }

        public IActionResult Index()
        {
            Dictionary<string, IEnumerable<Subcategory>> dictionary = new();

            foreach (var category in _categoryRepository.Items)
            {
                dictionary.Add(category.Name, category.Subcategories);
            }
            return View(dictionary);
        }

        [ActionName("Product")]
        public IActionResult ShowProduct(Guid id)
        {
            Product product = _productRepository.Items.FirstOrDefault(p => p.Id == id);
            if (product is not null)
            {
                return View(product);
            }
            else
            {
                return NotFound();
            }

        }

        public IActionResult Search(Guid? subcategoryId, string comparer, decimal? minPrice, decimal? maxPrice, string search, int page = 1)
        {
            IEnumerable<Product> products = _productRepository.Items
                .Where(p => subcategoryId == null || p.Subcategory.Id == subcategoryId)
                .Where(p => minPrice == null || p.Price >= minPrice)
                .Where(p => maxPrice == null || p.Price <= maxPrice);

            if (search is not null)
                products = _searchService.GetSerchedProducts(products, search);
            if (comparer is not null)
                products = products.OrderBy(p => p, _productComparers[comparer]);

            return View(new ProductListViewModel()
            {
                Products = products.Skip((page - 1) * pageSize)
                                   .Take(pageSize),
                PagingInfo = new()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = products.Count(),
                },
                SubcategoryId = subcategoryId,
                SubcategoriesList = new SelectList(_subcategoryRepository.Items, "Id", "Name", subcategoryId),
                ComparersList = new SelectList(_productComparers.Keys, comparer),
                SearchText = search,
                MinPrice = products?.Min(p => p.Price),
                MaxPrice = products?.Max(p => p.Price),
                Comparer = comparer
            });
        }

        public IActionResult WhyWeAre()
        {
            return View();
        }
        public IActionResult WhereWeAre()
        {
            return View();
        }

    }

}


