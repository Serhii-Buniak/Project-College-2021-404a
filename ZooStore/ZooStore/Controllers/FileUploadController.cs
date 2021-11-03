//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.IO;
//using System.Threading.Tasks;
//using ZooStore.Data;
//using ZooStore.Models;
//using ZooStore.Models.Repositories;
//using ZooStore.Models.ViewModels;

//namespace ZooStore.Controllers
//{
//    public class FileUploadController : Controller
//    {
//        private readonly IProductRepository<Food> _repository;
//        private readonly IWebHostEnvironment _env;

//        public FileUploadController(IProductRepository<Food> repository, IWebHostEnvironment env)
//        {
//            _repository = repository;
//            _env = env;
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(Food product, IFormFile formFile)
//        {
//            string fileName = await UploadFile(formFile);
//            product.Image.ImageUrl = fileName;
//            _repository.Add(product);
//            return RedirectToAction("Index");
//        }



//        public async Task<string> UploadFile(IFormFile file)
//        {
//            string fileName = null;
//            if (file != null)
//            {
//                string uploadDir = Path.Combine(_env.WebRootPath, "uploads");
//                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
//                string filePath = Path.Combine(uploadDir, fileName);
//                using (var fileStream = new FileStream(filePath, FileMode.Create))
//                {
//                    await file.CopyToAsync(fileStream);
//                }
//            }
//            return fileName;
//        }
//    }
//}
