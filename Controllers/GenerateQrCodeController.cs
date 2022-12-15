using GeoPet.Services.PetService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;
using QRCoder;

namespace GeoPet.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class GenerateQrCodeController : ControllerBase
    {
        private readonly IPetService _petService;

        public GenerateQrCodeController(IPetService searchService)
        {
            _petService = searchService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GeneratedBarcode>> GetQrCode(int id)
        {
            QRCodeGenerator qRCodeGenerator= new QRCodeGenerator();
            var pet = await _petService.GetPetsById(id);
            if (pet == null) return NotFound();
            
            var json = JsonConvert.SerializeObject(pet);
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(json, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);

            Bitmap 
        }

        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream);
            }
        }
    }
}