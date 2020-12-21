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
        private readonly IRepository<Order> _orderRepository;

        public InvoiceService(IRepository<Invoice> invoiceRepo, IRepository<Order> orderRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepo;
            _orderRepository = orderRepository;
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


        public InvoiceViewModel AddInvoiceToOrder(int orderId)
        {
            Order order = _orderRepository.GetById(orderId);

            Invoice newInvoice = new Invoice
            {
                Order = order,
            };
            _invoiceRepository.Insert(newInvoice);
            return GetInvoice(orderId);
        }

        public void UpdateModel(InvoiceViewModel model)
        {
            InvoiceViewModel invoice = GetInvoice(model.OrderId);

                invoice.Address = model.Address;
                invoice.PaymentMethod = model.PaymentMethod;
                

           _invoiceRepository.Update(_mapper.Map<Invoice>(invoice));

        }

       
    }
}
