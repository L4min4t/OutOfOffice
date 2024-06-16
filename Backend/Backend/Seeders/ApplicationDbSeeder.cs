using Backend.Contexts;
using Backend.Lists;
using Backend.Lists.Employees;

namespace Backend.Seeders;

public class ApplicationDbSeeder
{
    public static async Task Initialize
        (IServiceProvider serviceProvider, User? applicationUser)
    {
        var applicationContext =
            serviceProvider.GetRequiredService<ApplicationContext>();
        await SeedTestUser(applicationUser, applicationContext);
    }
    
    private static async Task SeedTestUser
        (User? applicationUser, ApplicationContext applicationContext)
    {
        if (applicationUser is not null)
            if (applicationContext.Employees.FirstOrDefault
                    (u => applicationUser.Id == u.IdentityId) is null)
            {
                var user = new Employee
                {
                    IdentityId = applicationUser.Id,
                    FullName = applicationUser.FullName
                };
                
                applicationContext.Employees.Add(user);
                await applicationContext.SaveChangesAsync();
            }
    }
}
