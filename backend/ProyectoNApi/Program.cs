using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using FluentValidation;

using ProyectoNApi.Context;
using ProyectoNApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ProyectoNDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();

// Add OpenAPI services
builder.Services.AddOpenApi();

// Add CORS policy to allow frontend Next.js requests 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJs",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "https://localhost:3000") // My Next.js port
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add Validators
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddControllers();

var app = builder.Build();

// Middleware from Scalar and OpenAPI only in Development
if (app.Environment.IsDevelopment())
{

    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("ProyectoNApi")
            .WithTheme(ScalarTheme.Mars); // Puedes elegir temas molones
    });

     app.MapOpenApi(); // Maps the OpenAPI endpoint
}

app.UseHttpsRedirection();

// Activation of CORS after build
app.UseCors("AllowNextJs");
app.MapControllers();

app.Run();


