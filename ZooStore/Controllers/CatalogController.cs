using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZooStore.Models;
using ZooStore.Models.Repositories;
using ZooStore.Models.ViewModels;

namespace ZooStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CatalogController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IWebHostEnvironment _env;
        private SelectList SelectListSubcategories => new(_subcategoryRepository.Subcategories, "Id", "Name");
        public CatalogController(IProductRepository productRepository, ISubcategoryRepository subcategoryRepository, IWebHostEnvironment env)
        {
            _productRepository = productRepository;
            _subcategoryRepository = subcategoryRepository;
            _env = env;
        }
        public IActionResult Create()
        {
            ViewBag.Subcategories = SelectListSubcategories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductForm model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = await UploadFileAsync(model);
              

                _productRepository.Add(new Product()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    Unique = model.Unique,
                    Picture = uniqueFileName,
                    Properties = model.Properties,
                    Subcategory = _subcategoryRepository.Subcategories.First(m => m.Id == model.SubcategoryId)
                });

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Subcategories = SelectListSubcategories;
                return View();
            }
        }

        private async Task<string> UploadFileAsync(ProductForm model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {

                string uploadsFolder = Path.Combine(_env.WebRootPath, "upload");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (FileStream fileStream = new(filePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
