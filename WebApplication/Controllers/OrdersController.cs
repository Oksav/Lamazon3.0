using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebModels.Enums;
using WebModels.ViewModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IInvoiceService _invoiceService;

        public OrdersController(IOrderService orderService, IUserService userService,IInvoiceService invoiceService)
        {
            _orderService = orderService;
            _userService = userService;
            _invoiceService = invoiceService;

        }


        public IActionResult Index()
        {
            return Ok("fuck");
        }

        [HttpGet]
        public IActionResult UserOrders()
        {
            var user = _userService.GetByUsername(User.Identity.Name);
            OrderViewModel userOrder = _orderService.GetCurrentOrder(user.Id);

            return View(userOrder);

        }

        
        public IActionResult AddToCart(int productId)
        {

            UserViewModel user = _userService.GetByUsername(User.Identity.Name);
            OrderViewModel order = _orderService.GetCurrentOrder(user.Id);

            _orderService.AddProductToOrder(order.OrderId,productId , user.Id);


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

        public IActionResult DeleteProduct(int productId)
        {
            UserViewModel user = _userService.GetByUsername(User.Identity.Name);
            OrderViewModel order = _orderService.GetCurrentOrder(user.Id);

            _orderService.RemoveProductFromOrder(order.OrderId, productId);
            return RedirectToAction("UserOrders", "Orders"); 
        }

        public IActionResult PayNow(int orderId)
        {
            OrderViewModel order = _orderService.GetOrderById(orderId);


            if (order.Invoice == null)
            {
                InvoiceViewModel invoice = _invoiceService.AddInvoiceToOrder(order.OrderId);

                return View(invoice);
            }
            else
                return View(order.Invoice);


        }

        [HttpPost]
        public IActionResult PayNow(InvoiceViewModel model)
        {
            UserViewModel user = _userService.GetByUsername(User.Identity.Name);
            

            _invoiceService.UpdateModel(model);
            _orderService.ChangeStatus(model.OrderId, user.Id, StatusTypeViewModel.Paid);
            return RedirectToAction("YourInvoice", "Invoice");
            //error oti nema value za price
        }
    }
}