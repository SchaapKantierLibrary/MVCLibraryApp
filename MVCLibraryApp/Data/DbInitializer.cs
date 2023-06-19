using Microsoft.AspNetCore.Identity;
using MVCLibraryApp.Data;
using MVCLibraryApp.Models;
using System.Linq;
using System.Threading.Tasks;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context, UserManager<BezoekerModel> userManager, RoleManager<IdentityRole> roleManager)
    {
        context.Database.EnsureCreated();

        // Seed users
        await SeedUsersAndRoles(userManager, roleManager);

       
    }

    public static async Task SeedUsersAndRoles(UserManager<BezoekerModel> userManager, RoleManager<IdentityRole> roleManager)
    {
        var roleNames = new[] { "Bezoeker", "Medewerker", "Beheerder" };

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
                var user = new BezoekerModel
                {
                    UserName = userName,
                    Email = userName,
                    Naam = faker.Name.FullName(),
                    AbonnementID = 1
            };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    // Assign role to the user
                    await userManager.AddToRoleAsync(user, "Bezoeker");
                }
            }
        }

        // Seed admin user
        var adminUser = new BezoekerModel
        {
            UserName = "admin@example.com",
            Email = "admin@example.com",
            AbonnementID = 1,
            Naam = "Admin User" // Provide a non-null value for the Naam property
        };

        var adminPassword = "Password123!";

        var adminUserResult = await userManager.CreateAsync(adminUser, adminPassword);

        if (adminUserResult.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Beheerder");
        }
        // Seed Medewerker
        var MedewerkerUser = new BezoekerModel
        {
            UserName = "Medewerker@example.com",
            Email = "Medewerker@example.com",
            AbonnementID = 1,
            Naam = "Medewerker" // Provide a non-null value for the Naam property
        };

        var MedewerkerPassword = "Password123!";

        var MedewerkerUserResult = await userManager.CreateAsync(MedewerkerUser, MedewerkerPassword);

        if (MedewerkerUserResult.Succeeded)
        {
            await userManager.AddToRoleAsync(MedewerkerUser, "Medewerker");
        }
    }
}
