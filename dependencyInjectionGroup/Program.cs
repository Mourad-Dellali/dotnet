using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWeatherServices();

var app = builder.Build();

app.MapGet("/weather/city/{cityName}", (string cityName, IWeatherService weatherService) =>
{
    string? weatherInfo = weatherService.GetWeatherInfo(cityName);
    return Results.Ok(weatherInfo);
});

app.Run();


public interface IWeatherService
{
    string GetWeatherInfo(string cityname);
}
public class WeatherService : IWeatherService
{
    private IWeatherClient _weatherclient;
    public WeatherService(IWeatherClient weatherclient)
    {
        _weatherclient = weatherclient;
    }
    public string GetWeatherInfo(string cityname)
    {
        return _weatherclient.GetWeatherInfo(cityname);
    }
}
public interface IWeatherClient
{
    string GetWeatherInfo(string cityname);
}
public class WeatherClient : IWeatherClient
{
    public string GetWeatherInfo(string cityname)
    {
        return $"weather for {cityname} is " + $"{Random.Shared.Next(-10,40)} Celcius";
    }
 
}
