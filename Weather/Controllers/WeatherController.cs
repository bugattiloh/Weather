using Application.MediatR.GetTemperatureByDate;
using Application.MediatR.SaveTemperatureByDate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Weather.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WeatherController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeatherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize]
    public async Task<double> MoscowWeather([FromBody] DateTime date) => await _mediator.Send(new GetTemperatureByDateRequest(date));

    [HttpPost]
    [Authorize]
    public async Task<string> SaveMoscowWeather([FromBody] DateTime date)
    {
        await _mediator.Send(new SaveTemperatureByDateCommand(date));
        return "Данные сохранены!";
    }
}
