using MediaMarktProjectApi.Application;
using MediaMarktProjectApi.Infrastructure;
using MediaMarktProjectApi.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(
        new SlugifyParameterTransformer()));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5186", "http://localhost:5173") // URL de tu React
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
var app = builder.Build();

var enableSwagger = app.Configuration.GetValue<bool>("EnableSwagger", app.Environment.IsDevelopment());
if (enableSwagger)
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediaMarkt API v1");
    });
}

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
    app.UseCors(myAllowSpecificOrigins);
}

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        const int maxRetries = 5;
        var delay = TimeSpan.FromSeconds(5);
        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                break;
            }
            catch (Exception ex) when (attempt < maxRetries)
            {
                logger.LogWarning(ex, "Intento {Attempt}/{Max} de aplicar migraciones fall�. Reintentando en {Delay}s...", attempt, maxRetries, delay.TotalSeconds);
                await Task.Delay(delay);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "No se pudieron aplicar migraciones despu�s de {Max} intentos.", maxRetries);
                throw;
            }
        }
    }
    catch (Exception ex)
    {
        logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurri� un error al crear la base de datos.");
    }
}


app.Run();

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        // Esto convierte el nombre del controlador en minúsculas y añade el prefijo
        return value == null ? null : $"api/{value.ToString()?.ToLowerInvariant()}";
    }
}