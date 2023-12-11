using System.Reflection;
using ApiClayBiosecurity.Extensions;
using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Add AddAPlicationServices */
builder.Services.AddAplicationServices();

/* Add Cors */
builder.Services.ConfigureCors();

/* Add Config RAte Limiting */
builder.Services.ConfigureRatelimiting();

/* Add AutoMApper */
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

// Add JWT
/* builder.Services.AddJwt(builder.Configuration); */

/* Add connection to database */
builder.Services.AddDbContext<ApiClayBioSecurutyContext>(options =>
{
    string connectionStrings = builder.Configuration.GetConnectionString("MysqlConect");
    options.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<ApiClayBioSecurutyContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var _logger = loggerFactory.CreateLogger<Program>();
        _logger.LogError(ex, "Ocurrio un error durante la migracion !!");
    }
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

/* Use Cors */
app.UseCors("CorsPolicy");

/* Use RateLimiting */
app.UseIpRateLimiting();

// Add Authentication(JWT)
/* app.UseAuthentication(); */

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

/* dotnet ef dbcontext scaffold "server=localhost;user=root;password=campus2024;database=claybiosecurity" Pomelo.EntityFrameworkCore.MySql -s ApiClayBiosecurity -p Domain --context ApiClayBioSecurutyContext --context-dir Data --output-dir Entities */

/* dotnet ef dbcontext scaffold "server=localhost;user=camper;password=campus2024;database=claybiosecurity" MySql.EntityFrameworkCore -p Domain -o Entities */
