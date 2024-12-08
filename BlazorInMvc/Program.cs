using Domain.Data.Repository;
using Domain.DbContex;
using Domain.Services;
using Domain.Services.Inventory;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.EntityFrameworkCore;
using Domain.Services.Accounts;
using TradeDomainApp.Services.Inventory;

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




builder.Services.AddScoped<DbConnectionDapper>();

builder.Services.AddScoped<ProductRepository>();
//builder.Services.AddScoped<TaskService>();
//builder.Services.AddScoped<OrderService>();
//builder.Services.AddScoped<OrderServiceWithSp>();
builder.Services.AddScoped<ColorService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<InvoiceItemService>();
builder.Services.AddScoped<ProductSpecificationService>();
builder.Services.AddScoped<ProductSkuService>();
builder.Services.AddScoped<WarehouseService>();
builder.Services.AddScoped<WarehouseService>();
builder.Services.AddScoped<NotificationByService>();
builder.Services.AddScoped<CountryServiceV2>();
builder.Services.AddScoped<ShippingByService>();
builder.Services.AddScoped<UnitService>();
builder.Services.AddScoped<BusinessTypesService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<InvoiceTypeService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<ProductOrCupponCodeService>();
builder.Services.AddScoped<WarehouseService>();
builder.Services.AddScoped<EmailSetupService>();
builder.Services.AddScoped<SmsSettinsService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<BasicColumnPermissionService>();
builder.Services.AddScoped<PageDetailsService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<LanguageService>();
builder.Services.AddScoped<ProductCategoryService>();
builder.Services.AddScoped<AccHeadService>();
builder.Services.AddScoped<StatusSettingService>();
builder.Services.AddScoped<CurrencyService>();
builder.Services.AddScoped<ProductSubCategoryService>();
builder.Services.AddScoped<BrandService>();
builder.Services.AddScoped<ProductSizeService>();
builder.Services.AddScoped<CompanyBranceService>();
builder.Services.AddScoped<CustomerPaymentDtlsService>();
builder.Services.AddScoped<ProductSerialNumbersService>();
builder.Services.AddScoped<AccountsDailyExpanseService>();
builder.Services.AddScoped<PaymentTypesService>();
builder.Services.AddScoped<BillingPlanService>();
builder.Services.AddScoped<AccTypeServivce>();
builder.Services.AddScoped<BrandService>();
//builder.Services.AddScoped<BodyPartService>();
builder.Services.AddScoped<ProductMediaService>();
//builder.Services.AddSingleton<ProductRepositoyWithSp>();
//builder.Services.AddSingleton<TaskRepository>();
//builder.Services.AddSingleton<FileUploadService>();

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
