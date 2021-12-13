using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZooStore.Models;
using ZooStore.Models.Repositories;
using ZooStore.Models.ViewModels;

namespace ZooStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<AppUser> _userManager;

        public CartController(ICartRepository cartRepository, IProductRepository productRepository, UserManager<AppUser> userManager)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userManager = userManager;
        }

        public async Task<ViewResult> Index()
        {
            var user = await GetCurrentUserAsync();
            return View(user.Cart.CartDetails.ToList());
        }

        public async Task<IActionResult> AddProduct(long id)
        {
            Product product = await _productRepository.FindByIdAsync(id);
            var user = await GetCurrentUserAsync();

            _cartRepository.Add(product, user);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> RemoveProduct(long id)
        {
            Product product = await _productRepository.FindByIdAsync(id);
            var user = await GetCurrentUserAsync();

            _cartRepository.Remove(product, user);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        private async Task<AppUser> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
