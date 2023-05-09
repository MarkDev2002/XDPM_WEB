using System.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using QuanLyBanHang.DataAccess;
using QuanLyBanHang.Entity;
using QuanLyBanHang.Service;
using QuanLyBanHang.Service.implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";
    options.LogoutPath = "/User/Logout";
    options.AccessDeniedPath = "/User/AccessDenied";
});


//builder.Services.AddScoped<UserManager<IdentityUser>, UserManager<IdentityUser>>();
//builder.Services.AddScoped<SignInManager<IdentityUser>, SignInManager<IdentityUser>>();

//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//        .AddEntityFrameworkStores<ApplicationDbContext>()
//        .AddDefaultTokenProviders();

//builder.Services.AddScoped<RoleManager<IdentityRole>>();


builder.Services.AddScoped<ICustomerService, CustomerServices>();
builder.Services.AddScoped<IOrderService, OrderServices>();
builder.Services.AddScoped<IProductService, ProductServices>();
builder.Services.AddScoped<ICartService, CartServices>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailServices>();



var app = builder.Build();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "user",
//        pattern: "user/{action=Index}/{id?}",
//        defaults: new { controller = "User" });

//    endpoints.MapControllerRoute(
//        name: "admin",
//        pattern: "admin/{action=Index}/{id?}",
//        defaults: new { controller = "Admin" });

//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//});

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
