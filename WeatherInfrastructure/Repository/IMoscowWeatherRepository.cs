namespace WeatherInfrastructure.Repository;

public interface IMoscowWeatherRepository
{
    Task SaveTemperatureByDate(MoscowWeather moscowWeather, CancellationToken ct);
}