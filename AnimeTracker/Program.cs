using Microsoft.EntityFrameworkCore;
using AnimeTracker.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 39))
    ));

builder.Services.AddControllersWithViews();


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


app.UseEndpoints(endpoint =>
{

    _ = endpoint.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

    _ = app.MapControllerRoute(
    name: "anime",
    pattern: "{controller=Anime}/{action=Index}/{id?}"
).WithStaticAssets();

_ = app.MapControllerRoute(
    name: "user",
    pattern: "{controller=User}/{action=Signup}/{id?}"
).WithStaticAssets();




});





app.Run();
