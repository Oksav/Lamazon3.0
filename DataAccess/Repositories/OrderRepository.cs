using DataAccess.Interfaces;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class OrderRepository : BaseRepository<LamazonDbContext>, IRepository<Order>
    {
        public OrderRepository(LamazonDbContext context) : base(context) { }

       
        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders.Find(id);
        }

        public int Insert(Order entity)
        {
            _dbContext.Orders.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(Order entity)
        {
            Order order = _dbContext.Orders.FirstOrDefault(x => x.Id == entity.Id);
            if (order == null) return -1;

            order.Status = entity.Status;
            order.DateCreated = entity.DateCreated;

            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            Order order = _dbContext.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null) return -1;

            _dbContext.Orders.Remove(order);
            return _dbContext.SaveChanges();
        }

    }
}
