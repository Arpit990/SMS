using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using SpeakerManagementSystem.Context;
using SpeakerManagementSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var SpeakerManagementDbConnStr = configuration.SpeakerManagementConnectionString();

// Add services to the container.
builder.Services.AddDataLayer(SpeakerManagementDbConnStr);
builder.Services.AddSession();
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options => {
            options.LoginPath = "/Auth/Login"; // Specify your custom login path
            options.AccessDeniedPath = "/Auth/AccessDenied";
        });
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
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

//Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

//Seed database
//AppDbInitializer.Seed(app);
AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

app.Run();
