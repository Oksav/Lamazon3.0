using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModels.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryType Category { get; set; }
        [Required]
        public double Price { get; set; }
        public int Quantity { get; set; }
        public virtual IEnumerable<OrderProduct> OrderProducts { get; set; }



    }
}
