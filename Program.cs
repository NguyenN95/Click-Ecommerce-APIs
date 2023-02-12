using Click.common;
using Click.product;
using Click.weatherforecast;
using Microsoft.EntityFrameworkCore;

namespace Click;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var devCorsPolicy = "devCorsPolicy";

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddDbContext<StoreContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

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

        var apisV1 = app.MapGroup("/api/v1");

        apisV1.MapGroup("/weatherforecast")
           .MapWeatherForecastRoutes();

        apisV1.MapGroup("/products")
           .MapProductRoutes();

        app.Run();
    }
}
