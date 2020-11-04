using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebModels.ViewModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrdersController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }


        public IActionResult Index()
        {
            return Ok("fuck");
        }

        [HttpGet]
        public IActionResult UserOrders()
        {
            var user = _userService.GetByUsername(User.Identity.Name);
            IEnumerable<OrderViewModel> userOrder = _orderService.GetUserOrders(user.Id);

            return View(userOrder);

        }

        
        public IActionResult AddToCart(int productId)
        {

            UserViewModel user = _userService.GetByUsername(User.Identity.Name);

            _orderService.AddProductToOrder(productId , user.Id);


            return RedirectToAction("ListProducts", "Products");


        }

        [Authorize(Roles = "admin")]
        public IActionResult ListAllOrders()
        {
            return View(_orderService.GetAllOrders());
        }


        public IActionResult OrderDetails(int orderId)
        {
            return View(_orderService.GetOrderById(orderId));
        }
    }
}