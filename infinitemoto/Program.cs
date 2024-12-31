using infinitemoto.BusinessServices;
using Microsoft.EntityFrameworkCore;
using infinitemoto.Models;
using infinitemoto.ValidateService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using infinitemoto.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Database configuration
builder.Services.AddDbContext<DummyProjectSqlContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "your-temporary-secret-key-min-16-chars"))
        };
    });

  

// Add services
builder.Services.AddControllers();
builder.Services.AddScoped<IUserInfoServices, UserInfoServices>();
builder.Services.AddScoped<IUserInfoValidation, UserInfoValidation>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IRegistrationDto, RegistrationDto>();
builder.Services.AddScoped<IEventregistrationDto, EventregistrationDto>();

builder.Services.AddScoped<JwtService>(); // Register JwtService
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Infinite Moto API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html", permanent: false);
        return;
    }
    await next();
});
  // Register services and add custom converter for DateOnly



// Middleware setup
app.UseHttpsRedirection();
app.UseAuthentication(); // Add this line
app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();
app.Run();
