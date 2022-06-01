using System;
using System.Threading.Tasks;

namespace PreciousMetalSpotPriceMicroservice.Services
{
    public interface ICalloutService
    {
        Task<string> GetLatestGoldSpotPriceAsync();
    }
}
