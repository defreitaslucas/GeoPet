using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GeoPet.Models;
using GeoPet.Services.PetService;

namespace GeoPet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetService _petService;
        public PetController(IPetService petService)
        {
            _petService = (PetService?)petService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pet>>> GetAllPets()
        {
            return await _petService.GetAllPets();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Pet>> GetPetsById(int id)
        {
            var pet = await _petService.GetPetsById(id);
            if (pet is null) return NotFound("Sorry, but this pet doesn't exist.");
            return Ok(pet);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pet>>> AddPet(Pet body)
        {
            var pet = await _petService.AddPet(body);
            return Ok(pet);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<Pet>>> UpdatePet(int id, Pet body)
        {
            var pet = await _petService.UpdatePet(id, body);
            if (pet is null) return NotFound("Sorry, but this pet doesn't exist.");
            return Ok(pet);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Pet>>> DeletePet(int id)
        {
            var pet = await _petService.DeletePet(id);
            if (pet is null) return NotFound("Sorry, but this pet doesn't exist.");
            return Ok(pet);
        }
    }
}