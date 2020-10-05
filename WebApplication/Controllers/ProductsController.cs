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
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
      //  private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public ProductsController(
            IProductService productService,
           // IOrderService orderService,
            IUserService userService)
        {
            _productService = productService;
           // _orderService = orderService;
           // _userService = userService;
        }


        [Authorize(Roles = "admin")]
        public IActionResult ListProducts()
        {
            return View("Index",_productService.GetAllProducts());
        }



       





    }
}