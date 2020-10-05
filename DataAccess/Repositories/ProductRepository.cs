using DataAccess.Interfaces;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class ProductRepository : BaseRepository<LamazonDbContext>, IRepository<Product>
    {
        public ProductRepository(LamazonDbContext context) : base(context) { }

       
        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Product entity)
        {
            _dbContext.Products.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(Product entity)
        {
            Product product = _dbContext.Products.FirstOrDefault(x => x.Id == entity.Id);
            if (product == null) return -1;

            product.Name = entity.Name;
            product.Price = entity.Price;
            product.Description = entity.Description;
            product.Category = entity.Category;

            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            Product product = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return -1;

            _dbContext.Products.Remove(product);
            return _dbContext.SaveChanges();
        }

    }
}
