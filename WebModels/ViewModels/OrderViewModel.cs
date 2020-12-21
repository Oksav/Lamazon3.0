using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebModels.Enums;

namespace WebModels.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public StatusTypeViewModel Status { get; set; }
        public DateTime DateCreated { get; set; }
        public double Price => Products.Sum(p => p.Price);
        public UserViewModel User { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public InvoiceViewModel Invoice { get; set; }
    }
}
