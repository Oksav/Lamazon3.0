using DataAccess.Interfaces;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class OrderProductRepository : BaseRepository<LamazonDbContext>, IRepository<OrderProduct>
    {
        public OrderProductRepository(LamazonDbContext context) : base(context) { }

        

        public IEnumerable<OrderProduct> GetAll()
        {
            return _dbContext.OrderProducts.ToList();
        }

        public OrderProduct GetById(int id)
        {
            return _dbContext.OrderProducts.FirstOrDefault(x => int.Parse($"{x.OrderId}{x.ProductId}") == id);
        }

        public int Insert(OrderProduct entity)
        {
            _dbContext.OrderProducts.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(OrderProduct entity)
        {
            return -1;

        }

        public int Delete(int id)
        {
            OrderProduct op = _dbContext.OrderProducts.FirstOrDefault(x => int.Parse($"{x.OrderId}{x.ProductId}") == id);
            if (op == null) return -1;

            _dbContext.OrderProducts.Remove(op);
            return _dbContext.SaveChanges();
        }
    }
}
