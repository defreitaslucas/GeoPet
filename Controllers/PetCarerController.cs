using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GeoPet.Models;

namespace GeoPet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetCarerController : ControllerBase
    {
        private static List<PetCarer> petCarers = new List<PetCarer>
        {
            new PetCarer
            {
                PetCarerId = 1,
                Name = "Lucas",
                Email = "lucas.dfa@live.com",
                ZipCode = 31210030,
                Password = "123456",
                PetId = null
            },
            new PetCarer
            {
                PetCarerId = 2,
                Name = "Giulia",
                Email = "giuliaavelinomattos@gmail.com",
                ZipCode = 31150520,
                Password = "123456",
                PetId = null
            }
        };
        [HttpGet]
        public async Task<ActionResult<List<PetCarer>>> GetAllPetCarers()
        {
            return Ok(petCarers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PetCarer>> GetPetCarersById(int id)
        {
            var petCarer = petCarers.Find(x => x.PetCarerId == id);
            if (petCarer is null) return NotFound("Sorry, but this pet doesn't exist.");
            return Ok(petCarer);
        }

        [HttpPost]
        public async Task<ActionResult<List<PetCarer>>> AddPetCarer(PetCarer body)
        {
            petCarers.Add(body);
            return Ok(petCarers);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<PetCarer>>> UpdatePetCarer(int id, PetCarer body)
        {
            var petCarer = petCarers.Find(x => x.PetCarerId == id);
            if (petCarer is null) return NotFound("Sorry, but this pet doesn't exist.");

            petCarer.Name = body.Name;
            petCarer.Email = body.Email;
            petCarer.ZipCode = body.ZipCode;
            petCarer.Password = body.Password;
            petCarer.PetId = body.PetId;

            return Ok(petCarers);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<PetCarer>>> DeletePetCarer(int id)
        {
            var petCarer = petCarers.Find(x => x.PetCarerId == id);
            if (petCarer is null) return NotFound("Sorry, but this pet doesn't exist.");

            petCarers.Remove(petCarer);

            return Ok(petCarers);
        }
    }
}
