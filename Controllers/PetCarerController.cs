using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GeoPet.Services.PetCarerService;
using GeoPet.Models;

namespace GeoPet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetCarerController : ControllerBase
    {
        private readonly PetCarerService _petCarerService;
        public PetCarerController(IPetCarerService petCarerService)
        {
            _petCarerService = (PetCarerService?)petCarerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PetCarer>>> GetAllPetCarers()
        {
            return await _petCarerService.GetAllPetCarers();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PetCarer>> GetPetCarersById(int id)
        {
            var result = await _petCarerService.GetPetCarersById(id);
            if (result is null) return NotFound("Pet Carer not found.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<PetCarer>>> AddPetCarer(PetCarer body)
        {
            try
            {
                var result = await _petCarerService.AddPetCarer(body);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<List<PetCarer>>> UpdatePetCarer(int id, PetCarer body)
        {
            var result = await _petCarerService.UpdatePetCarer(id, body);
            if (result is null) return NotFound("Pet Carer not found.");
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<PetCarer>>> DeletePetCarer(int id)
        {
            var result = await _petCarerService.DeletePetCarer(id);
            if (result is null) return NotFound("Pet Carer not found.");
            return Ok(result);
        }
    }
}