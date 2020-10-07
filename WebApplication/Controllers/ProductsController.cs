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
        public IActionResult AddProduct() //works
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AddProduct(ProductViewModel model) //works
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
        public IActionResult DeleteProduct(int id)   //does not work
        {
            _productService.RemoveProduct(id);
            return RedirectToAction("Delete Product", "Products");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            ProductViewModel product = _productService.GetProductById(id);
            ViewBag.Product = product;
            return View();
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductViewModel model)
        {
            _productService.UpdateProduct(model);
            return RedirectToAction("ListProducts", "Products");
        }



       





    }
}