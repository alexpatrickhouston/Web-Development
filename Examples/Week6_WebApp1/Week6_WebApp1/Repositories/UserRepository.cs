﻿using System.Collections.Generic;
using Week6_WebApp1.Data;
using Week6_WebApp1.Data.Entities;

namespace Week6_WebApp1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUser(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users;
        }

        public void SaveUser(User user)
        {
            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _dbContext.Users.Find(id);

            if (user == null) return;

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}