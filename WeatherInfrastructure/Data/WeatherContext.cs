using Microsoft.EntityFrameworkCore;

namespace WeatherInfrastructure;

public class WeatherContext : DbContext
{

    public WeatherContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<MoscowWeather> MoscowWeathers { get; set; }
    public DbSet<User> Users { get; set; }
}