using Microsoft.AspNetCore.Authentication.Cookies;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.İnterfaces;
using MultiShop.WebUI.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        //options.LogoutPath = "/Login/Logout";
        //options.AccessDeniedPath = "/Pages/AccessDenied";

        options.Cookie.Name = "MultiShopCookie";
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;

        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.SlidingExpiration = true;
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

builder.Services.Configure<ClientSetings>(
    builder.Configuration.GetSection("ClientSettings")
);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
