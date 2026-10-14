using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using FluentValidation;

using ProyectoNApi.Context;
using ProyectoNApi.Services;
using Microsoft.AspNetCore.Identity;
using ProyectoNApi.Entities;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ProyectoNDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

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

// Add configuration of ASP.NET Core Identity
builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<ProyectoNDbContext>()
.AddDefaultTokenProviders();

// Add authentication system using cookies
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme; //HttpOnly Cookies to keep the session active 
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme; // Temporary while the user is in the process of authenticating with an external server 
})
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
    googleOptions.CallbackPath = "/signin-google";
});

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

app.UseAuthentication(); // Read the HttpOnly cookie from the browser and authenticates the user.
app.UseAuthorization(); // Checks the user permissions.

// Activation of CORS after build
app.UseCors("AllowNextJs");
app.MapControllers();

app.Run();


