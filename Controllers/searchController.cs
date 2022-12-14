using GeoPet.Models.Responses;
using GeoPet.Services.SearchService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using Newtonsoft;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http;

namespace GeoPet.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class searchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public searchController(ISearchService searchService)
        {
            searchService = _searchService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAddress(double lat, double lon)
        {
            var result = await _searchService.GetAddress(lat, lon);

            return Ok(result.address);
        }
    }
}