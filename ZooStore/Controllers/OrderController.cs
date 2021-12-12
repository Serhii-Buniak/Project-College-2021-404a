using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZooStore.Models;
using ZooStore.Models.Repositories;
using ZooStore.Services.EmailServices;

namespace ZooStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailSender _emailSender;

        public OrderController(IOrderRepository orderRepository, IProductRepository productRepository, IDepartmentRepository departmentRepository, UserManager<AppUser> userManager, IEmailSender emailSender)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _departmentRepository = departmentRepository;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> Create(OrderDetails[] orderDetails)
        {
            foreach (var details in orderDetails)
            {
                if (details.Product == null)
                {
                    details.Product = await _productRepository.FindByIdAsync(details.ProductId);
                }
            }
            return View(new Order() { OrderDetails = orderDetails });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {


            if (TryValidateModel(order))
            {
                AppUser user = await _userManager.GetUserAsync(User);
                order.User = user;
                order.Department = await _departmentRepository.FindByIdAsync(order.Department.Id);
                foreach (var details in order.OrderDetails)
                {
                    details.Product = await _productRepository.FindByIdAsync(details.ProductId);
                }
                _orderRepository.Add(order);

                Message message = new(new string[] { order.User.Email }, "ZooStore", $"Сума до оплати: {String.Format("{0:f2}", order.TotalPrice)}₴\nВідділення: {order.Department.Name}\nМи працюємо: {order.Department.WorkTime}");
                _emailSender.SendEmail(message);
                return RedirectToAction(nameof(OrderConfirmed), new { order.Id });
            }
            else
            {
                foreach (var details in order.OrderDetails)
                {
                    details.Product = await _productRepository.FindByIdAsync(details.ProductId);
                }
                return View(order);
            }
        }

        public IActionResult OrderConfirmed(int id)
        {
            return View(id);
        }
    }
}
