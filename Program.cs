using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoListApp.WebApi.Models;
using UrlShortener.BAL.Interfaces;
using UrlShortener.BAL.Services;
using UrlShortener.DAL.Context;
using UrlShortener.DAL.Interfaces;
using UrlShortener.DAL.Repository;
using UrlShortener.Helpers;
using UrlShortener.Helpers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<UrlDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UrlConnection")));

builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<UsersDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromMinutes(2));

builder.Services.AddScoped<IUrlRepository, UrlRepository>();
builder.Services.AddScoped<IUrlDetailsRepository, UrlDetailsRepository>();

builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddScoped<IUrlDetailsService, UrlDetailsService>();

builder.Services.AddScoped<IUrlChecker, UrlChecker>();
builder.Services.AddScoped<IShortener, Shortener>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await IdentitySeedData.EnsurePopulated(app);

await app.RunAsync();
