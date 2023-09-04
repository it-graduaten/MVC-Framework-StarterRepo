using _09_00_HelloCore.Data;
using _09_00_HelloCore.Models;
using _09_00_HelloCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registratie voor dependency injection van UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HelloCoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDBConnection")));
builder.Services.AddRazorPages();
// Swagger registreren
builder.Services.AddSwaggerGen();

//NewtonJSonSoft registreren
builder.Services.AddControllersWithViews().AddNewtonsoftJson(Options => Options
    .SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDefaultIdentity<CustomUser>().AddEntityFrameworkStores<HelloCoreContext>();
var app = builder.Build();


// Swagger middleware koppelen aan app
app.UseSwagger();

// SwaggerUI instellen met juiste JSON endpoint 
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});


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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
