using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainModels.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime DateOfPay { get; set; }  // prociti getters i setters da go namestis vremto avtomatski da pokazave

        [Required]
        public PaymentType PaymentMethod { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

    }
}
