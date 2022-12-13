/* namespace GeoPet.Models
{
    public class SeedData
    {
        private readonly GeoPetContext _context;

        public SeedData(GeoPetContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.PetCarers.Any() && !_context.Pets.Any())
            {
                var petCarers = new List<PetCarer>()
                {
                    new PetCarer()
                    {
                        Name = "Lucas",
                        Email = "lucas.dfa@live.com",
                        ZipCode = 31210030,
                        Password = "123456"
                    },
                    new PetCarer()
                    {
                        Name = "Giulia",
                        Email = "giuliaavelinomattos@gmail.com",
                        ZipCode = 31150520,
                        Password = "123456"
                    },
                };
                var pets = new List<Pet>()
                {
                    new Pet()
                    {
                        PetId = 1,
                        Name = "Ayka",
                        Age = 3,
                        Size = "Medium",
                        Breed = "Husky Siberiano",
                        HashLocalization = null
                    },
                    new Pet()
                    {
                        PetId = 2,
                        Name = "Kira",
                        Age = 4,
                        Size = "Large",
                        Breed = "Pastor Alemão",
                        HashLocalization = null
                    },
                    new Pet()
                    {
                        PetId = 3,
                        Name = "Skyper",
                        Age = 16,
                        Size = "small",
                        Breed = "Vira-Lata",
                        HashLocalization = null
                    },
                    new Pet()
                    {
                        PetId = 4,
                        Name = "Teste",
                        Age = 5,
                        Size = "Medium",
                        Breed = "Husky Siberiano",
                        HashLocalization = null
                    }
                };
                _context.PetCarers.AddRange(petCarers);
                _context.Pets.AddRange(pets);
                _context.SaveChanges();
            }
        }
    }
}
*/
