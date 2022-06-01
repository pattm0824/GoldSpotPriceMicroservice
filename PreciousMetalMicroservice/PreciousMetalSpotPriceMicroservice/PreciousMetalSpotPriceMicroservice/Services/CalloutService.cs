using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PreciousMetalSpotPriceMicroservice.Services
{
    public class CalloutService : ICalloutService
    {
        private static HttpClient _client;
        private readonly string _url = "https://api.metals.live/v1/spot/gold";

        public CalloutService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient();
        }

        public async Task<string> GetLatestGoldSpotPriceAsync()
        {
            var result = await _client.GetAsync(_url);
            result.EnsureSuccessStatusCode();
            return await GetPriceFromResponse(result);
        }

        private async Task<string> GetPriceFromResponse(HttpResponseMessage response)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            JArray jArray = JArray.Parse(jsonString);
            var price = jArray.FirstOrDefault()?["price"]?.Value<string>();
            return price;
        }
    }
}
