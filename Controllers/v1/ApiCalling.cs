using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using TweeterBackend.ActionsFilter;
using TweeterBackend.Options;

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
        private readonly IConfiguration _configuration;
        private WeatherApiOptions _weatherOptions;

        public ApiCalling(IHttpClientFactory httpClientFactory, IConfiguration configuration, IOptionsSnapshot<WeatherApiOptions> weatherOptions)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _weatherOptions = weatherOptions.Value;
        }

        [HttpGet]
        [AttributeAsyncActionFilter("async controller filter")]
        [AttributeSyncActionFilter("weather api")]
        public async Task<string> Get(string cityname)
        {
            // string baseUrl = _configuration.GetValue<string>("WeatherApi:url");
            // string key = _configuration.GetValue<string>("WeatherApi:key");

            string baseUrl = _weatherOptions.Url;
            string key = _weatherOptions.Key;


            string url = $"{baseUrl}?key={key}&q={cityname}&dt=2022-11-04";
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