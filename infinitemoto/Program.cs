
using infinitemoto.BusinessServices;
using Microsoft.EntityFrameworkCore;
using infinitemoto.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DummyProjectSqlContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
builder.Services.AddScoped<IUserInfoServices, UserInfoServices>();
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
app.UseAuthorization();
app.UseHttpsRedirection();


app.MapControllers();

app.Run();
