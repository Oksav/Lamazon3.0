using DataAccess.Interfaces;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebModels.ViewModels;

namespace Services.Interfaces
{
    public interface IInvoiceService 
    {
        void CreateInvoice(InvoiceViewModel invoice);
        InvoiceViewModel GetInvoice(int orderId);
    }
}
