using System.Collections.Generic;
using Week8_WebApp1.Data.Entities;

namespace Week8_WebApp1.Repositories
{
    public interface IPetRepository
    {
        Pet GetPet(int id);

        IEnumerable<Pet> GetPetsForUser(string userId);

        void SavePet(Pet pet);

        void UpdatePet(Pet user);

        void DeletePet(int id);
    }
}
