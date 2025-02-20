using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Weather.NET;
using Weather.NET.Enums;
namespace NET_CORE_DAY_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [HttpPost("location/{city}")]
        public IActionResult WeatherPost(string city)
        {
            try
            {
                string API_Key = "f2859064e653f0275cccf0bc0179efca";
                WeatherClient weather = new WeatherClient(API_Key);
                var currentweather = weather.GetCurrentWeather(city);
                return Ok(currentweather);
                
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}