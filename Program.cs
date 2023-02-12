using API.WeatherForecast;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var devCorsPolicy = "devCorsPolicy";

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version = "v1" });
        });

        // Cors
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(devCorsPolicy, policy =>
            {
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
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            // Serve the Swagger UI at the app's root (https://localhost:<port>/)
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", $"{builder.Environment.ApplicationName} v1");
                options.RoutePrefix = string.Empty;
            });
        }

        app.UseCors(devCorsPolicy);

        app.UseAuthorization();

        app.MapGroup("/weatherforecast")
           .MapWeatherForecastApis()
           .WithOpenApi();

        app.Run();
    }
}
