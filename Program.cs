using Click.weatherforecast;

namespace Click;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var devCorsPolicy = "devCorsPolicy";
        // Add services to the container.
        builder.Services.AddAuthorization();

        // Cors
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(devCorsPolicy, policy =>
            {
                // TODO: change later for production
                policy.WithOrigins("*")
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowAnyOrigin();
            });
        });
        // DI
        builder.Services.AddScoped<IWeatherForecastRepo, WeatherForecastRepo>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseCors(devCorsPolicy);

        app.UseAuthorization();

        app.MapGroup("/api/v1/weatherforecast")
           .MapWeatherForecastRoutes();

        app.Run();
    }
}
