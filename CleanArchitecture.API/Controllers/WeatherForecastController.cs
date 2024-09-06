using CleanArchitecture.API.Contracts;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };



    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ICarServices _services;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ICarServices services)
    {
        _logger = logger;
        _services = services;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost("/testing")]
    public async Task<ActionResult<CarContract>> CreateNew([FromBody]CarOperationsContract model)
    {
        var oDataModel = new Car
        {
            CarName = model.CarName
        };

        var oResult= await _services.Create(oDataModel);

        var oDataResult = new CarContract
        {
            CarName = oResult.CarName
        };

        return Ok(oDataResult);
    }
}


