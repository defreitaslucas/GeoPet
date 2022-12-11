using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GeoPet.Models;

namespace GeoPet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private static List<Pet> pets = new List<Pet>
        {
            new Pet
            {
                PetId = 1,
                Name = "Ayka",
                Age = 3,
                Size = "Medium",
                Breed = "Husky Siberiano",
                HashLocalization = null
            },
            new Pet
            {
                PetId = 2,
                Name = "Kira",
                Age = 4,
                Size = "Big",
                Breed = "Pastor Alemão",
                HashLocalization = null
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Pet>>> GetAllPets()
        {
            return Ok(pets);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PetCarer>> GetPetsById(int id)
        {
            var pet = pets.Find(x => x.PetId == id);
            if (pet is null) return NotFound("Sorry, but this pet doesn't exist.");
            return Ok(pet);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pet>>> AddPet(Pet body)
        {
            pets.Add(body);
            return Ok(pets);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<Pet>>> UpdatePet(int id, Pet body)
        {
            var pet = pets.Find(x => x.PetId == id);
            if (pet is null) return NotFound("Sorry, but this pet doesn't exist.");
            pet.Name = body.Name;
            pet.Age = body.Age;
            pet.Size = body.Size;
            pet.Breed = body.Breed;
            pet.PetCarerId = body.PetCarerId;
            pet.HashLocalization = body.HashLocalization;
            return Ok(pets);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Pet>>> DeletePet(int id)
        {
            var pet = pets.Find(x => x.PetId == id);
            if (pet is null) return NotFound("Sorry, but this pet doesn't exist.");
            pets.Remove(pet);
            return Ok(pets);
        }
    }
}