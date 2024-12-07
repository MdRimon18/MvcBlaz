using Domain.DbContex;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Enable detailed exceptions for development
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
 
builder.Services.Configure<CircuitOptions>(options =>
{
    options.DetailedErrors = true;
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Add this line to register Razor Pages services
builder.Services.AddServerSideBlazor();
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
// Map Razor Pages
app.MapRazorPages(); // Add this line to enable Razor Pages routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



// Map Blazor Hub for server-side Blazor
app.MapBlazorHub();

// Map fallback to the _Host.cshtml for Blazor
app.MapFallbackToPage("/_Host");
// Map routes for MVC controllers




app.Run();
