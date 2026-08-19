var builder = WebApplication.CreateBuilder(args);

// Añadimos servicios de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Añadimos los servicios de OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

// Activar el middleware de Swagger y de OpenAPI solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // Esto habilita la interfaz web gráfica (/swagger)
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "ProyectoNApi v1"); // // Conecta la UI con la ruta del JSON generado por .NET, ProyectoNApi v1 es el nombre que aparecerá en el desplegable del selector de versiones
        options.RoutePrefix = "swagger"; // La UI estará en https://localhost:7277/swagger
    });

     app.MapOpenApi(); // Mapea el endpoint de OpenAPI
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
