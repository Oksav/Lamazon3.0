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

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public IActionResult YourInvoice(int orderId)
        {
            InvoiceViewModel model = _invoiceService.GetInvoice(orderId);
            return View(model);
        }
    }
}