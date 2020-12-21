using DataAccess.Interfaces;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class InvoiceRepository : BaseRepository<LamazonDbContext>, IRepository<Invoice>
    {
        public InvoiceRepository(LamazonDbContext context) : base(context) { }

        

        public IEnumerable<Invoice> GetAll()
        {
            return _dbContext.Invoices;
        }

        public Invoice GetById(int id)
        {
            return _dbContext.Invoices.SingleOrDefault(x => x.InvoiceId == id);
        }

        public int Insert(Invoice entity)
        {
            _dbContext.Invoices.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(Invoice entity)
        {
           Invoice invoice = _dbContext.Invoices.FirstOrDefault(x => x.InvoiceId == entity.InvoiceId);
           if (invoice == null) return -1;
           else
            {
                invoice.Adress = entity.Adress;
                invoice.PaymentMethod = entity.PaymentMethod;
            }
                      

            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            Invoice invoice = _dbContext.Invoices.FirstOrDefault(x => x.InvoiceId == id);
            if (invoice == null) return -1;

            _dbContext.Invoices.Remove(invoice);
            return _dbContext.SaveChanges();
        }
    }
}
