using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace TweeterBackend.Controllers.v1
{
    [EnableCors("Version01_CORS_Policy")]
    [Route("[controller]")]
    [BindProperties(SupportsGet = true)]
    [Consumes("application/json")]
    [ApiController]
    public class ApiCalling : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiCalling(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<string> Get(string cityname)
        {
            var url =
                $"http://api.weatherapi.com/v1/astronomy.json?key=a797fbce57e548daa0842806220411&q={cityname}&dt=2022-11-04";
            // var httpClient = new HttpClient()
            // Default Client
            // var httpClient = _httpClientFactory.CreateClient();
            // Named Client
            var httpClient = _httpClientFactory.CreateClient("weather");
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}