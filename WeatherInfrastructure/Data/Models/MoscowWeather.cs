namespace WeatherInfrastructure;

public class MoscowWeather
{
    public int Id  { get; set; }
    
    public DateTime Date  { get; set; }
    
    public double Temperature  { get; set; }

    public MoscowWeather(DateTime date, double temperature)
    {
        Date = date;
        Temperature = temperature;
    }
}