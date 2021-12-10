using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ZooStore.Models;
using ZooStore.Models.Repositories;
using ZooStore.Services.CartServices;

namespace ZooStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartService _cartService;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppUser _user;

        public CartController(IProductRepository productRepository, ICartService cartService, UserManager<AppUser> userManager, AppUser user)
        {
            _productRepository = productRepository;
            _cartService = cartService;
            _userManager = userManager;
            _user = user;
        }

        public async Task<ViewResult> Index()
        {
            AppUser user = await _userManager.GetUserAsync(HttpContext.User);
            
            return View(user.Cart);
        }

        public void AddOrRemoveProduct(Guid id)
        {
      
     
        }

    }
}
