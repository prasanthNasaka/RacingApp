using infinitemoto.BusinessServices;
using Microsoft.EntityFrameworkCore;
using infinitemoto.Models;
using infinitemoto.ValidateService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using infinitemoto.DTOs;
using infinitemoto.Services;
using System.Text.Json.Serialization;
using infinitemoto.LookUps;
using Microsoft.AspNetCore.Builder;

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
builder.Services.AddScoped<IJwtService, JwtService>();  // Register JwtService for JWT handling
 builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IRegistrationreqDto, RegistrationreqDto>();
builder.Services.AddScoped<IRegistrationresDto, RegistrationresDto>();
builder.Services.AddScoped<IEventregistrationReqDto, EventregistrationReqDto>();
builder.Services.AddScoped<IEventCategoryService, EventCategoryService>();
builder.Services.AddScoped<IVehicleDto, VehicleDTO>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IDriverDTO, DriverDTO>();
builder.Services.AddScoped<IDriverDTO,DriverDTO>();
builder.Services.AddScoped<ITeamDTO, TeamDTO>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IVehicledocDto, VehicleDocDTO>();
builder.Services.AddScoped<DriverService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IVehicleDocService, VehicleDocService>();
builder.Services.AddScoped<IEventRegistrationService, EventRegistrationService>();
builder.Services.AddScoped<IEventregistrationResDto, EventregistrationResDto>();
builder.Services.AddScoped<IEventcategoriesgetDto, EventCategorygetDto>();
builder.Services.AddScoped<IEventCategoryCreateDto, EventCategoryCreateDto>();

// error handling
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});


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
           Array.Empty<string>()
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

// Enable static file serving for a custom folder
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/images"
});

// Middleware setup
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");  // Ensure CORS is before Auth middleware
app.UseAuthentication();
app.UseAuthorization();

// Map controllers
app.MapControllers();
app.Run();
