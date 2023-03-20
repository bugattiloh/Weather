using System.Text.Json;
using Application.DTO;
using Microsoft.AspNetCore.WebUtilities;

namespace Application.Clients;

public class WeatherHttpClient
{
    private readonly HttpClient _httpClient;


    public WeatherHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    
    public async Task<MoscowWeatherDto?> Forecast(DateTime request, CancellationToken cancellationToken)
    {
        var date = request.Date.ToString("yyyy-MM-dd");

        var url = "forecast";

        url = QueryHelpers.AddQueryString(url, "latitude", "55.75");
        url = QueryHelpers.AddQueryString(url, "longitude", "37.62");
        url = QueryHelpers.AddQueryString(url, "hourly", "temperature_2m");
        url = QueryHelpers.AddQueryString(url, "start_date", date);
        url = QueryHelpers.AddQueryString(url, "end_date", date);

        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();
        
        var responseString = await response.Content.ReadAsStringAsync(cancellationToken);

        var dto = JsonSerializer.Deserialize<MoscowWeatherDto>(responseString);

        return dto;
    }
}