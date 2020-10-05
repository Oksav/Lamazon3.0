using AutoMapper;
using DataAccess.Interfaces;
using DomainModels.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebModels.ViewModels;

namespace Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IRepository<Invoice> _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IRepository<Invoice> invoiceRepo, IMapper mapper)
        {
            _invoiceRepository = invoiceRepo;
            _mapper = mapper;
        }

        public void CreateInvoice(InvoiceViewModel invoice)
        {
            _invoiceRepository.Insert(_mapper.Map<Invoice>(invoice));
        }

        public InvoiceViewModel GetInvoice(int orderId)
        {
            Invoice invoice = _invoiceRepository.GetAll().FirstOrDefault(i => i.OrderId == orderId);
            if (invoice == null)
                throw new Exception("Invoice is not generated");

            return _mapper.Map<InvoiceViewModel>(invoice);
        }
    }
}
