using System;
using System.Collections.Generic;
using System.Text;
using WebModels.Enums;

namespace WebModels.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public StatusTypeViewModel Status { get; set; }
        public double Price { get; set; }
        public UserViewModel User { get; set; }
        public List<ProductViewModel> Products { get; set; }
        //public InvoiceViewModel Invoice { get; set; }
    }
}
