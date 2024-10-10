using EmployeeManagementApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var employeeDbConnectionString = builder.Configuration.GetConnectionString("EmployeeDBContext")
    ?? throw new InvalidOperationException("Connection string 'EmployeeDBContext' not found.");
builder.Services.AddDbContext<EmployeeDBContext>(options =>
    options.UseSqlServer(employeeDbConnectionString));


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();  

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    // Check if the user is authenticated
    if (!context.User.Identity.IsAuthenticated
        && !context.Request.Path.StartsWithSegments("/Identity/Account/Login")
        && !context.Request.Path.StartsWithSegments("/Identity/Account/Register"))
    {
        // Redirect to login page if not authenticated
        context.Response.Redirect("/Identity/Account/Login");
    }
    else
    {
        // If authenticated or accessing login/register, continue to the next middleware
        await next();
    }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
