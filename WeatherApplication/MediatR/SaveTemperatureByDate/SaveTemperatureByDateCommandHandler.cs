using System.Text.Json;
using Application.DTO;
using MediatR;
using WeatherInfrastructure;
using WeatherInfrastructure.Repository;

namespace Application.MediatR.SaveTemperatureByDate;

public class SaveTemperatureByDateCommandHandler : IRequestHandler<SaveTemperatureByDateCommand>, IDisposable
{
    private readonly IMoscowWeatherRepository _repository;
    private readonly HttpClient _httpClient;

    public SaveTemperatureByDateCommandHandler(IMoscowWeatherRepository repository, IHttpClientFactory httpClientFactory)
    {
        _repository = repository;
        _httpClient = httpClientFactory.CreateClient("weather");
    }

    public async Task Handle(SaveTemperatureByDateCommand request, CancellationToken cancellationToken)
    {
        var date = request.Date.ToString("yyyy-MM-dd");
        var response =
            await _httpClient.GetAsync(
                $"forecast?latitude=55.75&longitude=37.62&hourly=temperature_2m&start_date={date}&end_date={date}",
                cancellationToken);


        var responseString = await response.Content.ReadAsStringAsync(cancellationToken);
        var dto = JsonSerializer.Deserialize<MoscowWeatherDto>(responseString);

        var moscowWeather = new MoscowWeather(request.Date, (double)dto.hourly.temperature_2m.First(x => x.HasValue));

        await _repository.SaveTemperatureByDate(moscowWeather, cancellationToken);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}