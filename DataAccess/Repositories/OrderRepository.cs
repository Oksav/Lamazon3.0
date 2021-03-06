﻿using DataAccess.Interfaces;
using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
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
            return _dbContext.Orders
                .Include(o => o.Invoice)
                .Include(o => o.OrderProducts)
                .ThenInclude(po => po.Product)
                .Include(o => o.User);
                
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(po => po.Product)
                .Include(o => o.User)
                .Include(o => o.Invoice)
                .FirstOrDefault(o => o.OrderId == id);
        }

        public int Insert(Order entity)
        {
            _dbContext.Orders.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(Order entity)
        {
            _dbContext.Orders.Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            Order order = _dbContext.Orders.FirstOrDefault(x => x.OrderId == id);
            if (order == null) return -1;

            _dbContext.Orders.Remove(order);
            return _dbContext.SaveChanges();
        }

    }
}
