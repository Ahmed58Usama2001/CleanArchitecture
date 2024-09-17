using CleanArchitecture.API.Contracts;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Brokers;
using CleanArchitecture.Infrastructure.Factories;
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
    private readonly IMainBroker _mainBroker;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ICarServices services, IMainBroker mainBroker)
    {
        _logger = logger;
        _services = services;
        _mainBroker = mainBroker;
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

    [HttpPost("Factory/{type}")]
    public IActionResult FactoryBuilder([FromRoute]string type)
    {
        var dbcontext = DbContextFactory.ContextBuilder(type);

        return Ok(dbcontext.GetDbContextBasedOnType());
    }

    [HttpPost("Broker")]
    public IActionResult Broker(string url, string content)
    {
        var oPost=_mainBroker.Post(url, content);

        var oGet = _mainBroker.Get(url);

        var oPut=_mainBroker.Put(url, content);

        var oDelete=_mainBroker.Delete(url);

        return Ok($"Post:{oPost} - Get:{oDelete} - Put:{oPut} - Delete:{oDelete}");
    }
}


