using AArkhipenko.Core.Logging;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace AArkhipenko.Core.Test.Controllers;

[ApiController]
// Версионирование
[ApiVersion("10", Deprecated = false)]
[Route("[controller]/v{version:apiVersion}")]
// Добавление прослойки для логирования методов
public class WeatherForecastController : LoggingControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
        : base(logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        // Логирование метода
        using(_ = base.BeginLoggingScope())
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
