using Microsoft.EntityFrameworkCore;
using TheDarkTowerMVC.Data;
using TheDarkTowerMVC.Models.Repository;
using TheDarkTowerMVC.Models.Service;
using TheDarkTowerMVC.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.IsEssential = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adaugare logger
Console.WriteLine("Building Logging");
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnectionString");
    //Console.WriteLine("Connection string: " + connectionString);
    options.UseNpgsql(connectionString);
});

Console.WriteLine("Connection string: " + builder.Configuration.GetConnectionString("PostgreSQLConnectionString"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<UserRepo>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<PlayerRepo>();
builder.Services.AddScoped<PlayerService>();

builder.Services.AddScoped<GameMasterRepo>();
builder.Services.AddScoped<GameMasterService>();

builder.Services.AddScoped<IMessageProducer, RegisterEmailQueue>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


