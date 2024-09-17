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
    private readonly IExternalServices _externalServices;
    private readonly IConfiguration _configuration;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ICarServices services, IMainBroker mainBroker, IExternalServices externalServices,
        IConfiguration configuration)
    {
        _logger = logger;
        _services = services;
        _mainBroker = mainBroker;
        _externalServices = externalServices;
        _configuration = configuration;
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


    [HttpPost("externalService")]
    public async Task<IActionResult> externalServicePost([FromBody] SharedProduct model)
    {
        var oResult = await _externalServices.Post<SharedProduct, SharedProduct>(_configuration["ExternalApi"], model);

        return Ok(oResult); 
    }

    [HttpGet("externalService")]
    public async Task<IActionResult> externalService()
    {
        var oResult = await _externalServices.Get<List<SharedProduct>>(_configuration["ExternalApi"]);

        return Ok(oResult);
    }

    [HttpGet("externalService/{id}")]
    public async Task<IActionResult> externalService([FromRoute]int id)
    {
        var oResult = await _externalServices.Get<SharedProduct>($"{_configuration["ExternalApi"]}/{id}");

        return Ok(oResult);
    }

    [HttpDelete("externalService/{id}")]
    public async Task<IActionResult> DeleteExternalService([FromRoute] int id)
    {
        var oResult = await _externalServices.Delete($"{_configuration["ExternalApi"]}/{id}");

        return Ok(oResult);
    }
}


