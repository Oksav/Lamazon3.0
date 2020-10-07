using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

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
           return View(_orderService.GetUserOrders(user.Id));

            
        }

        



    }
}