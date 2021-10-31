using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProject.Models;
using MyProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReadOnlyProductRepository<Product> _repository;

        public HomeController(IReadOnlyProductRepository<Product> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.Items.First());
        }

    }
}
