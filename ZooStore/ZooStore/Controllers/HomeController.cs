using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ZooStore.Controllers.Extensions;
using ZooStore.Models;
using ZooStore.Models.Repositories;
using ZooStore.Models.ViewModels;

namespace ZooStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReadOnlyRepository<Product> _productRepository;

        public HomeController(IReadOnlyRepository<Product> repository)
        {
            _productRepository = repository;
        }
        public IActionResult Index()
        {
            

            return View(new GroupedCategories()
            {
                AnimalsCategories = _productRepository.Items.GetCategoriesForType(typeof(Animal)),
                FoodsCategories = _productRepository.Items.GetCategoriesForType(typeof(Food)),
                AccessoriesCategories = _productRepository.Items.GetCategoriesForType(typeof(Accessory))
            });
        }
         




























        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

