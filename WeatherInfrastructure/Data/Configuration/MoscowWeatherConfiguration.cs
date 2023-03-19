using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeatherInfrastructure.Configuration;

public class MoscowWeatherConfiguration : IEntityTypeConfiguration<MoscowWeather>
{
    public void Configure(EntityTypeBuilder<MoscowWeather> builder)
    {
        builder.HasKey(x => x.Id);
    }
}