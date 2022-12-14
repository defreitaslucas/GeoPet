using GeoPet.Services.SearchService;
using Microsoft.AspNetCore.Mvc;

namespace GeoPet.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAddress(double lat, double lon)
        {
            var result = await _searchService.GetAddress(lat, lon);

            return Ok(result.address);
        }
    }
}