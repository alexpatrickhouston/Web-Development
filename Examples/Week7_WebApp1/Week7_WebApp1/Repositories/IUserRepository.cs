﻿using System.Collections.Generic;
using Week6_WebApp1.Data.Entities;

namespace Week6_WebApp1.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);

        IEnumerable<User> GetAllUsers();

        void SaveUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);
    }
}
