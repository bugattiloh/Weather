using Application.Clients;
using MediatR;


namespace Application.MediatR.GetTemperatureByDate;

public class GetTemperatureByDateRequestHandler : IRequestHandler<GetTemperatureByDateRequest, double>
{
    private readonly WeatherHttpClient _weatherHttpClient;

    public GetTemperatureByDateRequestHandler(WeatherHttpClient weatherHttpClient)
    {
        _weatherHttpClient = weatherHttpClient;
    }

    public async Task<double> Handle(GetTemperatureByDateRequest request, CancellationToken cancellationToken)
    {
        var forecast = await _weatherHttpClient.Forecast(request.Date, cancellationToken);
        var result = (double)forecast.Hourly.Temperature2m.First(x => x.HasValue);
        return result;
    }
}