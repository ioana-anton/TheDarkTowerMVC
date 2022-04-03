using Microsoft.EntityFrameworkCore;
using TheDarkTowerMVC.Data;
using TheDarkTowerMVC.Entity;
using TheDarkTowerMVC.Models.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnectionString");
    Console.WriteLine(connectionString);
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<UserRepo>();
builder.Services.AddScoped<UserService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");

app.MapControllers();

app.Run();


