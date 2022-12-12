namespace GeoPet.Models
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
            if (!_context.PetCarers.Any())
            {
                var petCarers = new List<PetCarer>()
                {
                    new PetCarer()
                    {
                        PetCarerId = 1,
                        Name = "Lucas",
                        Email = "lucas.dfa@live.com",
                        ZipCode = 31210030,
                        Password = "123456"
                    },
                    new PetCarer()
                    {
                        PetCarerId = 2,
                        Name = "Giulia",
                        Email = "giuliaavelinomattos@gmail.com",
                        ZipCode = 31150520,
                        Password = "123456"
                    },
                };
                _context.PetCarers.AddRange(petCarers);
                _context.SaveChanges();
            }
            if (!_context.Pets.Any())
            {
                var pets = new List<Pet>()
                {
                    new Pet()
                    {
                        PetId = 1,
                        Name = "Ayka",
                        Age = 3,
                        Size = "Medium",
                        Breed = "Husky Siberiano",
                        HashLocalization = null,
                        PetCarerId = 1,
                    },
                    new Pet()
                    {
                        PetId = 2,
                        Name = "Kira",
                        Age = 4,
                        Size = "Large",
                        Breed = "Pastor Alemão",
                        HashLocalization = null,
                        PetCarerId = 2,
                    },
                    new Pet()
                    {
                        PetId = 3,
                        Name = "Skyper",
                        Age = 16,
                        Size = "small",
                        Breed = "Vira-Lata",
                        HashLocalization = null,
                        PetCarerId = 1,
                    },
                    new Pet()
                    {
                        PetId = 4,
                        Name = "Teste",
                        Age = 5,
                        Size = "Medium",
                        Breed = "Husky Siberiano",
                        HashLocalization = null,
                        PetCarerId = 1,
                    }
                };
                _context.Pets.AddRange(pets);
                _context.SaveChanges();
            }
        }
    }
}

