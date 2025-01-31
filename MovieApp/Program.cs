using Microsoft.EntityFrameworkCore;

using MovieApp.Models;
using MovieApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// first let's get db conn string from app settings:
string ? dbConn = builder.Configuration.GetConnectionString("MovieContext");

// let's register our db context and config it as a sql svr connect:
builder.Services.AddDbContext<MovieContext>(options => options.UseSqlServer(dbConn));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
