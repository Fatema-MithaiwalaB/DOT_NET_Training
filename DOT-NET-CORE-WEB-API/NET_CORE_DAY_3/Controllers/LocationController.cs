using Microsoft.AspNetCore.Mvc;
using Weather.NET;

namespace NET_CORE_DAY_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private const string AllowedCity = "Ahmedabad";

        public LocationController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("weather/{city}")]
        public IActionResult GetWeather(string city)
        {
            if (!string.Equals(city, AllowedCity, StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest(new { Message = "Access restricted! Only Ahmedabad weather data is allowed." });
            }

            try
            {
                var weatherData = _weatherService.GetWeather(city);
                return Ok(weatherData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error fetching weather data.", Error = ex.Message });
            }
        }
    }
}
