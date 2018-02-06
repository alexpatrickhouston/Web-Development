using System.Collections.Generic;
using Week5_WebApp1.Models.View;

namespace Week5_WebApp1.Services
{
    public interface IPetService
    {
        PetViewModel GetPet(int id);

        IEnumerable<PetViewModel> GetPetsForUser(int userId);

        void SavePet(PetViewModel pet);

        void UpdatePet(PetViewModel user);

        void DeletePet(int id);
    }
}
