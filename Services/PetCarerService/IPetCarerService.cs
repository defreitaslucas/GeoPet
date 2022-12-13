using GeoPet.Models;

namespace GeoPet.Services.PetCarerService
{
    public interface IPetCarerService
    {
        Task<List<PetCarer>> GetAllPetCarers();
        Task<PetCarer?> GetPetCarersById(int id);
        Task<List<PetCarer>> AddPetCarer(PetCarer body);
        Task<List<PetCarer>?> UpdatePetCarer(int id, PetCarer body);
        Task<List<PetCarer>?> DeletePetCarer(int id);
    }
}
