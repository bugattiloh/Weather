using Microsoft.EntityFrameworkCore;

namespace WeatherInfrastructure.Repository;

public class MoscowWeatherRepository : IMoscowWeatherRepository
{
    private readonly WeatherContext _context;

    public MoscowWeatherRepository(WeatherContext context)
    {
        _context = context;
    }

    public async Task SaveTemperatureByDate(MoscowWeather moscowWeather,CancellationToken ct)
    {
        var checkObject = await _context.MoscowWeathers.FirstOrDefaultAsync(x => x.Date == moscowWeather.Date, cancellationToken: ct);

        if (checkObject != null)
        {
            throw new Exception("Упс, такая информация уже уже есть");
        }
        await _context.MoscowWeathers.AddAsync(moscowWeather, ct);

        await _context.SaveChangesAsync(ct);
    }
}