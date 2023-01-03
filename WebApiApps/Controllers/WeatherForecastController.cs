using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiApps.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("wrapped")]
        public ActionResult<IEnumerable<WeatherForecast>> GetWrapped()
        {
            var rng = new Random();
            var list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(new { Properties = list });
        }

        [HttpGet("Version")]
        public ContentResult GetVersion() =>
            Content("v1.0.0");

        [HttpGet("Error")]
        public IActionResult GetError() =>
            Problem("Something went wrong.");

        [HttpGet("LoggingOverview")]
        public ActionResult<IEnumerable<string>> LoggingOverview()
        {
            //Info level traces are not captured by default
            _logger.LogInformation("An example of an Info trace..");

            _logger.LogWarning("An example of a Warning trace..");
            _logger.LogError("An example of an Error level message");

            return new string[] { "value1", "value2" };
        }
    }
}
