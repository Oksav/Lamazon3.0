using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebModels.Enums;

namespace WebModels.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public PaymentTypeViewModel PaymentMethod { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public int OrderId { get; set; }
        public OrderViewModel Order { get; set; }
    }
}
