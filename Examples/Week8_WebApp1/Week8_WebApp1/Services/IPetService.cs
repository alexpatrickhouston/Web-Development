using System.Collections.Generic;
using Week8_WebApp1.Models.View;

namespace Week8_WebApp1.Services
{
    public interface IPetService
    {
        PetViewModel GetPet(int id);

        IEnumerable<PetViewModel> GetPetsForUser(string userId);

        void SavePet(string userId, PetViewModel pet);

        void UpdatePet(PetViewModel user);

        void DeletePet(int id);
    }
}
