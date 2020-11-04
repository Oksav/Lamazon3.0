using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModels.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public StatusType Status { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; }


    }
}
