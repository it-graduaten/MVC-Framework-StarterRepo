using HelloCore.Data;
using HelloCore.Models;
using HelloCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registratie voor dependency injection van UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Registratie voor dependency injection van Generieke repository van de entiteit Klant
builder.Services.AddScoped<IGenericRepository<Klant>,GenericRepository<Klant>>();

// Registratie voor dependency injection van CategorieRepository
builder.Services.AddScoped<ICategorieRepository, CategorieRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HelloCoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDBConnection")));
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
