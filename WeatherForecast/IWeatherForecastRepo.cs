namespace API.WeatherForecast;

public interface IWeatherForecastRepo
{
    string[] GetSummaries();
}