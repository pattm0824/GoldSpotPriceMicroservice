using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PreciousMetalSpotPriceMicroservice.Responses;
using PreciousMetalSpotPriceMicroservice.Services;

namespace PreciousMetalSpotPriceMicroservice.Controllers
{
    [ApiController]
    [Route("api/spot_price")]
    public class SpotPriceController : ControllerBase
    {
        private readonly ICalloutService _calloutService;


        public SpotPriceController(ICalloutService calloutService)
        {
            _calloutService = calloutService;
        }

        [HttpGet("gold")]
        public async Task<ActionResult<SpotPriceResponse>> GetGoldSpotPrice()
        {
            var result = await _calloutService.GetLatestGoldSpotPriceAsync();

            return Ok(new SpotPriceResponse() { SpotPrice = result }); 
        }
    }
}
