using Microsoft.AspNetCore.Authentication.JwtBearer;
using RealEstateDapperUI.Services;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("ApiSettingsKey"));

//builder.Services.AddScoped<AppSettings>();

// Add services to the container.
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index";
    opt.LogoutPath = "/Login/LogOut";
    opt.AccessDeniedPath = "/Pages/AccessDenied";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite = SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "RealEstateJwt";
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");


app.Run();
