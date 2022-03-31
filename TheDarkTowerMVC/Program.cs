using Microsoft.EntityFrameworkCore;
using TheDarkTowerMVC.Data;
using TheDarkTowerMVC.Entity;
using TheDarkTowerMVC.Models.Service;

/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    //var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnectionString");
    // Console.WriteLine(connectionString);
    //options.UseNpgsql(connectionString);

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
*/
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnectionString");
    Console.WriteLine(connectionString);
    options.UseNpgsql(connectionString);

    // var connectionString = builder.Configuration.GetConnectionString("MySQLConnectionString");
    //Console.WriteLine(connectionString);
    //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});



// build.Services.AddDbContext<DatabaseContext>(options =>
//   options.UseNpgsql(Configuration.GetConnectionString("BloggingContext")));

builder.Services.AddScoped<UserRepo>();
builder.Services.AddScoped<UserService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddRazorPages();



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
