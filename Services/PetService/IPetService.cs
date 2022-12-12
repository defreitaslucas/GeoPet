using GeoPet.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeoPet.Services.PetService
{
    public interface IPetService
    {
        Task<List<Pet>> GetAllPets();
        Task<Pet?> GetPetsById(int id);
        Task<List<Pet>> AddPet(Pet body);
        Task<List<Pet>?> UpdatePet(int id, Pet body);
        Task<List<Pet>?> DeletePet(int id);
    }
}
