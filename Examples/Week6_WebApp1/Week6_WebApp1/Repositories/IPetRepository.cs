﻿using System.Collections.Generic;
using Week6_WebApp1.Data.Entities;

namespace Week6_WebApp1.Repositories
{
    public interface IPetRepository
    {
        Pet GetPet(int id);

        IEnumerable<Pet> GetPetsForUser(int userId);

        void SavePet(Pet pet);

        void UpdatePet(Pet user);

        void DeletePet(int id);
    }
}
