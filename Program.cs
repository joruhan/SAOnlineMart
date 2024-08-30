using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using SAOnlineMart.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the database Users context to the services container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the JewelryDbContext for Jewelry
builder.Services.AddDbContext<JewelryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("JewelryDbConnection")));

// Register the ClothingDbContext for Clothing
builder.Services.AddDbContext<ClothingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClothingDbConnection")));

// Configure authentication and authorization services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Adjust session expiration time as needed
    });

// Add authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

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

// Use authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Map the default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map the area routes
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Optionally map specific routes like Jewelry (this is not necessary unless you have custom requirements)
app.MapControllerRoute(
    name: "jewelry",
    pattern: "Jewelry/{action=Index}/{id?}",
    defaults: new { controller = "Jewelry", action = "Index" });

app.Run();
