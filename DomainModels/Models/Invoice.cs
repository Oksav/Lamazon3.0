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
        public int InvoiceId { get; set; }

       
        public DateTime DateOfPay { get; set; }  

        
        public PaymentType PaymentMethod { get; set; }

        
        public string Adress { get; set; }

       
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

    }
}
