using System;
using System.Collections.Generic;
using System.Linq;
using ApiExampleBackEnd.DB;
using ApiExampleBackEnd.Models;
using ApiExampleBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiExampleBackEnd.Controllers
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
        private readonly ApiExampleContext _dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApiExampleContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
        }

        [HttpPost("calculate")]
        public CalculationsResult CalculateTwoNumbers([FromBody] CalculateRequest request)
        {
            _dbContext.CalculateRequests.Add(request);
            _dbContext.SaveChanges();
            var result = CalculationService.Calculate(request.Number1, request.Number2);
            _dbContext.CalculationsResult.Add(result);
            _dbContext.SaveChanges();
            return result;
        }
    }
}