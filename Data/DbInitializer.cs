using Microsoft.AspNetCore.Identity;
using MVCLibraryApp.Data;
using MVCLibraryApp.Models;
using System.Linq;
using System.Threading.Tasks;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context, UserManager<VisitorModel> userManager, RoleManager<IdentityRole> roleManager)
    {
        context.Database.EnsureCreated();

        // Seed users
        await SeedUsersAndRoles(userManager, roleManager);

       
    }

    public static async Task SeedUsersAndRoles(UserManager<VisitorModel> userManager, RoleManager<IdentityRole> roleManager)
    {
        var roleNames = new[] { "Visitor", "Employee", "Admin" };

        // Seed roles
        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Seed users
        var faker = new Bogus.Faker();

        for (int i = 0; i < 100; i++)
        {
            var userName = $"user{i}@example.com";
            var password = $"Password123!";

            if ((await userManager.FindByNameAsync(userName)) == null)
            {
                var user = new VisitorModel
                {
                    UserName = userName,
                    Email = userName,
                    Name = faker.Name.FullName(),
                    AbonnementID = 1
            };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    // Assign role to the user
                    await userManager.AddToRoleAsync(user, "Visitor");
                }
            }
        }

        // Seed admin user
        var adminUser = new VisitorModel
        {
            UserName = "admin@example.com",
            Email = "admin@example.com",
            AbonnementID = 1,
            Name = "Admin User" // Provide a non-null value for the Name property
        };

        var adminPassword = "Password123!";

        var adminUserResult = await userManager.CreateAsync(adminUser, adminPassword);

        if (adminUserResult.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
        // Seed Employee
        var MedewerkerUser = new VisitorModel
        {
            UserName = "Employee@example.com",
            Email = "Employee@example.com",
            AbonnementID = 1,
            Name = "Employee" // Provide a non-null value for the Name property
        };

        var MedewerkerPassword = "Password123!";

        var MedewerkerUserResult = await userManager.CreateAsync(MedewerkerUser, MedewerkerPassword);

        if (MedewerkerUserResult.Succeeded)
        {
            await userManager.AddToRoleAsync(MedewerkerUser, "Employee");
        }
    }
}
