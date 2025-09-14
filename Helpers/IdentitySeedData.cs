using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UrlShortener.DAL.Context;

namespace TodoListApp.WebApi.Models;

public static class IdentitySeedData
{
    private const string adminUser = "Admin";
    private const string adminPassword = "Secret123$";
    private const string userPassword = "user";

    public static async Task EnsurePopulated(IApplicationBuilder app)
    {
        UsersDbContext context = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<UsersDbContext>();

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        UserManager<IdentityUser> userManager = app.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();

        IdentityUser user = await userManager.FindByNameAsync(adminUser);

        if (user is null)
        {
            user = new IdentityUser("Admin")
            {
                Email = "admin@example.com",
                PhoneNumber = "555-1234"
            };

            await userManager.CreateAsync(user, adminPassword);

            user = new IdentityUser("User")
            {
                Email = "user@example.com",
                PhoneNumber = "555-1234"
            };

            await userManager.CreateAsync(user, adminPassword);
        }
    }
}

