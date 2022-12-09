using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Portfolio.Data.DAL;
using Serilog;
using Serilog.Events;
using Microsoft.EntityFrameworkCore;
using Portfolio.Business.Services.Implementations;
using Portfolio.Business.Services.Interfaces;
using Portfolio.Core.Entities;
using Portfolio.Core.Interfaces.UnitOfWork;
using Portfolio.Data.Implementations.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);


#region Logger

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.File(
            Path.Combine("Logs", "Log.txt"),
            rollingInterval: RollingInterval.Day,
            fileSizeLimitBytes: 10 * 1024 * 1024,
            retainedFileCountLimit: 30,
            rollOnFileSizeLimit: true,
            shared: true,
            flushToDiskInterval: TimeSpan.FromSeconds(2))
        .WriteTo.Console();
});

#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();


#region DataBase

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

#endregion

#region Identity

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Lockout.MaxFailedAccessAttempts = 15;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(5);
    options.Lockout.AllowedForNewUsers = true;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});

#endregion

#region Cooike

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
    });

#endregion

#region UnitOfWork

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();

#endregion
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


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();