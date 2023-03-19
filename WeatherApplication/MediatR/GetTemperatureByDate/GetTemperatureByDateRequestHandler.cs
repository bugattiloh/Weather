using System.Text.Json;
using Application.DTO;
using MediatR;
using WeatherInfrastructure.Repository;


namespace Application.MediatR.GetTemperatureByDate;

public class GetTemperatureByDateRequestHandler : IRequestHandler<GetTemperatureByDateRequest, double>, IDisposable
{
    private readonly HttpClient _httpClient;

    public GetTemperatureByDateRequestHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("weather");
    }

    public async Task<double> Handle(GetTemperatureByDateRequest request, CancellationToken cancellationToken)
    {
        var date = request.Date.ToString("yyyy-MM-dd");
        var response =
            await _httpClient.GetAsync(
                $"forecast?latitude=55.75&longitude=37.62&hourly=temperature_2m&start_date={date}&end_date={date}",
                cancellationToken);
        var responseString = await response.Content.ReadAsStringAsync(cancellationToken);
        var dto = JsonSerializer.Deserialize<MoscowWeatherDto>(responseString);
        
        return (double)dto.hourly.temperature_2m.First(x => x.HasValue);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}