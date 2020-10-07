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


        [Authorize]
        public IActionResult ListProducts()
        {
            return View("Index",_productService.GetAllProducts());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productService.CreateProduct(model);
                return RedirectToAction("ListProducts", "Products");
            }
            else
                return View(model);
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public IActionResult DeleteProduct()
        {
            IEnumerable<ProductViewModel> products = _productService.GetAllProducts();
            ViewBag.Products = products;
            return View(products);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]        
        public IActionResult DeleteProduct(int id)
        {
            _productService.RemoveProduct(id);
            return RedirectToAction("Delete Product", "Products");
        }



       





    }
}