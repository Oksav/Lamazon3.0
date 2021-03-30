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
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }



        public IActionResult ListProducts()
        {
            return View(_productService.GetAllProducts());
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
        [Authorize(Roles = "admin")]
        public IActionResult ModifyProduct()
        {
            IEnumerable<ProductViewModel> products = _productService.GetAllProducts();
            // ViewBag.Products = products;
            return View(products);
        }


        [Authorize(Roles = "admin")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.RemoveProduct(id);
            return RedirectToAction("ModifyProduct", "Products");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateProduct(int id)
        {
            ProductViewModel product = _productService.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateProduct(ProductViewModel model)
        {
            _productService.UpdateProduct(model);
            return RedirectToAction("ModifyProduct", "Products");
        }


    }
}