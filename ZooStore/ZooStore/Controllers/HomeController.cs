using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IReadOnlyRepository<Product> _productRepository;
        public HomeController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            Dictionary<string, IEnumerable<string>> dictionary = new();    
            
            foreach (var category in _categoryRepository.Items)
            {
                dictionary.Add(category.Name, category.Subcategories.Select(s => s.Name));
            }
            return View(dictionary);
        }

        public ViewResult Product()
        {

            return View(_productRepository.Items.Skip(2).First());
        }
    }
}

