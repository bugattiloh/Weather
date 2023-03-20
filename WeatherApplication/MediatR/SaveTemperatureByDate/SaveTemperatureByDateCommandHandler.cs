using Application.Clients;
using MediatR;
using WeatherInfrastructure;
using WeatherInfrastructure.Repository;

namespace Application.MediatR.SaveTemperatureByDate;

public class SaveTemperatureByDateCommandHandler : IRequestHandler<SaveTemperatureByDateCommand>
{
    private readonly IMoscowWeatherRepository _repository;
    private readonly WeatherHttpClient _weatherHttpClient;

    public SaveTemperatureByDateCommandHandler(IMoscowWeatherRepository repository, WeatherHttpClient weatherHttpClient)
    {
        _repository = repository;
        _weatherHttpClient = weatherHttpClient;
    }

    public async Task Handle(SaveTemperatureByDateCommand request, CancellationToken cancellationToken)
    {
        var dto = await _weatherHttpClient.Forecast(request.Date, cancellationToken);

        var moscowWeather = new MoscowWeather(request.Date, (double)dto.Hourly.Temperature2m.First(x => x.HasValue));

        await _repository.SaveTemperatureByDate(moscowWeather, cancellationToken);
    }
}