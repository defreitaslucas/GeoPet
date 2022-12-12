using GeoPet.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoPet.Services.PetCarerService
{
    public class PetCarerService : IPetCarerService
    {
        private readonly GeoPetContext _context;

        public PetCarerService(GeoPetContext context)
        {
            _context = context;
        }

        public async Task<List<PetCarer>> AddPetCarer(PetCarer body)
        {
            _context.PetCarers.Add(body);
            await _context.SaveChangesAsync();
            return await _context.PetCarers.ToListAsync();
        }

        public async Task<List<PetCarer>?> DeletePetCarer(int id)
        {
            var petCarer = await _context.PetCarers.FindAsync(id);

            if (petCarer is null) return null;

            _context.PetCarers.Remove(petCarer);
            await _context.SaveChangesAsync();
            return await _context.PetCarers.ToListAsync();
        }

        public async Task<List<PetCarer>> GetAllPetCarers()
        {
            var result = await _context.PetCarers.ToListAsync();
            return result;
        }

        public async Task<PetCarer?> GetPetCarersById(int id)
        {
            var petCarer = await _context.PetCarers.FindAsync(id);
            if (petCarer is null) return null;
            return petCarer;
        }

        public async Task<List<PetCarer>?> UpdatePetCarer(int id, PetCarer body)
        {
            var petCarer = await _context.PetCarers.FindAsync(id);

            if (petCarer is null) return null;

            petCarer.Name = body.Name;
            petCarer.Email = body.Email;
            petCarer.ZipCode = body.ZipCode;
            petCarer.Password = body.Password;

            await _context.SaveChangesAsync();

            return await _context.PetCarers.ToListAsync();
        }
    }
}
