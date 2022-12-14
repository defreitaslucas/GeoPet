using Microsoft.AspNetCore.Mvc;
using IronBarCode;
using System;
using System.Drawing;
using System.Linq;
using GeoPet.Services.PetService;

namespace GeoPet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenerateQrCodeController : ControllerBase
    {
        private readonly IPetService _petService;

        public GenerateQrCodeController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        [Route("{id")]
        public async Task<ActionResult<GeneratedBarcode>> GetQrCode(int petId)
        {
            var pet = await _petService.GetPetsById(petId);
            if (pet == null) return NotFound();
            var convertPet = pet.ToString();

            GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(convertPet, 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsHtmlFile("PetInformation.html");
            return barcode;
        }
    }
}
