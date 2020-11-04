using DataAccess.Interfaces;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class UserRepository : BaseRepository<LamazonDbContext>, IUserRepository<User>
    {
      public UserRepository(LamazonDbContext context) : base(context) { }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(string id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(x => x.UserName == username);
        }

        public int Insert(User entity)
        {
            _dbContext.Users.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(User entity)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.Id == entity.Id);
            if (user == null) return -1;

            //user.NormalizedEmail = entity.NormalizedEmail;
            //user.Email = entity.Email;
            //user.NormalizedUserName = entity.NormalizedUserName;
            //user.UserName = entity.UserName;

             _dbContext.Users.Update(entity);

            return _dbContext.SaveChanges();
        }

        public int Delete(string id)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) return -1;

            _dbContext.Users.Remove(user);
            return _dbContext.SaveChanges();
        }

      
    }
}
