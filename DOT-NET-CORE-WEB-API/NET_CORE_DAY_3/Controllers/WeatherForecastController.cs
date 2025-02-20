using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet("cause-error")]
    public IActionResult CauseError()
    {
        throw new Exception("This is a test exception!"); // 🔹 This will trigger the error middleware
    }
}
