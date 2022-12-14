using GeoPet.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GeoPet.Services.SearchService
{
    public interface ISearchService
    {
        Task<AddressResponse> GetAddress(double lat, double lon);
    }
}
