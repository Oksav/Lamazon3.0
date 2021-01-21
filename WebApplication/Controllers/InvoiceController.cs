using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using WebModels.ViewModels;

namespace WebApplication.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IOrderService _orderService;

        public InvoiceController(IInvoiceService invoiceService, IOrderService orderService)
        {
            _invoiceService = invoiceService;
            _orderService = orderService;
        }

        
        public IActionResult YourInvoice(int orderId)
        {
            string currentUser = User.Identity.Name;
            OrderViewModel model = _orderService.GetOrderById(orderId);
            if(model.User.Username != currentUser)
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return View(model);
        }
    }
}