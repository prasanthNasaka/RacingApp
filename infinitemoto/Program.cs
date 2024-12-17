using infinitemoto.BusinessServices;
using Microsoft.EntityFrameworkCore;
using infinitemoto.Models;
using infinitemoto.ValidateService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Add these lines in this order
app.UseHttpsRedirection();
app.UseAuthentication(); // Add this line
app.UseAuthorization();

app.MapControllers();
app.Run();