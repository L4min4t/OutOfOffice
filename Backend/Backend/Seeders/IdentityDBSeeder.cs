using Backend.Lists;
using Microsoft.AspNetCore.Identity;

namespace Backend.Seeders;

public static class IdentityDBSeeder
{
    public static async Task<User?> Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        await SeedRolesAsync(roleManager);
        return await SeedTestUserAsync(userManager);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roleNames = { "Admin", "User", "HR", "PM" };
        
        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }

    private static async Task<User?> SeedTestUserAsync(UserManager<User> userManager)
    {
        const string email = "admin@google.com";
        const string userName = "administrator";
        const string password = "Pass1!";

        if (await userManager.FindByEmailAsync(email) == null)
        {
            var user = new User()
            {
                FullName = userName,
                UserName = email,
                Email = email
            };

            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                string[] roleNames = { "Admin", "User", "HR", "PM" };

                foreach (var roleName in roleNames)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
                
                return user;
            }
        }
        
        return null;
    }
}