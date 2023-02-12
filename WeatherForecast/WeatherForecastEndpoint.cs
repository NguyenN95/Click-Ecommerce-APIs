namespace API.WeatherForecast;

public static class WeatherForecastEndpoint
{
    public static RouteGroupBuilder MapWeatherForecastApis(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetWeatherForecast);
        return group;
    }

    public static IResult GetWeatherForecast(HttpContext httpContext, IWeatherForecastRepo weatherForecastRepo)
    {
        var summaries = weatherForecastRepo.GetSummaries();
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecastModel
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                })
                .ToArray();
        return Results.Ok(forecast);
    }
}