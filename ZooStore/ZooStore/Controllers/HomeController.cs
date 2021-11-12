using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ZooStore.Models;
using ZooStore.Models.Repositories;

namespace ZooStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReadOnlyRepository<Category> _categoryRepository;
        private readonly IReadOnlyRepository<Subcategory> _subcategoryRepository;
        private readonly IReadOnlyRepository<Product> _productRepository;

        private readonly static IDictionary<string, IComparer<Product>> _productComparers = new Dictionary<string, IComparer<Product>>()
        {
            ["Від дорогих до дешевих"] = new PeopleComparerByPriceAscending(),
            ["Від дешевих до дорогих"] = new PeopleComparerByPriceDescending(),
        };

        public HomeController(ICategoryRepository categoryRepository, ISubcategoryRepository subcategoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _productRepository = productRepository;
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

        public IActionResult Search(Guid? subcategoryId, string comparer, decimal? minPrice, decimal? maxPrice)
        {
            IEnumerable<Product> products = _productRepository.Items;

            if (subcategoryId is not null)
                products = products.Where(p => p.Subcategory.Id == subcategoryId);

            if (comparer is not null)
                products = products.OrderByDescending(p => p, _productComparers[comparer]);

            if (minPrice is not null)
                products = products.Where(p => p.Price >= minPrice);

            if (maxPrice is not null)
                products = products.Where(p => p.Price <= maxPrice);

            ViewBag.Subcategories = new SelectList(_subcategoryRepository.Items, "Id", "Name", subcategoryId);

            ViewBag.Comparers = new SelectList(_productComparers.Keys, comparer);

            if (products.Any())
            {
                ViewBag.MinPrice = products.Min(p => p.Price) ;
                ViewBag.MaxPrice = products.Max(p => p.Price);
            }
            return View(products);
        }

    }

    public class PeopleComparerByPriceAscending : IComparer<Product>
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
    public class PeopleComparerByPriceDescending : IComparer<Product>
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

