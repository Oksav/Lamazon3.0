using System;
using System.Collections.Generic;
using System.Text;
using WebModels.Enums;

namespace WebModels.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryTypeViewModel Category { get; set; }
        public double Price { get; set; }
    }
}
