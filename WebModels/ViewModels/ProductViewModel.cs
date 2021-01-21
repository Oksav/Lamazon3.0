using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using WebModels.Enums;

namespace WebModels.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public CategoryTypeViewModel Category { get; set; }
        public double Price { get; set; }
        public IFormFile Photo { get; set; }
        public string PhotoPath { get; set; }
    }
}
