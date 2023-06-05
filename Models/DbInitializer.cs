using Microsoft.AspNetCore.Identity;
using MVCLibraryApp.Models;
using System.Linq;
using System.Threading.Tasks;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context, UserManager<BezoekerModel> userManager, RoleManager<IdentityRole> roleManager)
    {
        context.Database.EnsureCreated();

        // Seed roles
        await SeedRoles(roleManager);

        // Seed Abonnementen
        SeedAbonnementen(context);

        // Seed users
        await SeedUsersAndRoles(userManager, roleManager);

        // Seed Locations
        SeedLocations(context);
    }

    private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        if (!(await roleManager.RoleExistsAsync("Bezoeker")))
        {
            IdentityRole role = new IdentityRole { Name = "Bezoeker" };
            IdentityResult result = await roleManager.CreateAsync(role);
        }

        // Add more roles here if needed
    }

    private static void SeedAbonnementen(ApplicationDbContext context)
    {
        // Check if Abonnementen already exist
        if (!context.Abonnementen.Any())
        {
            var abonnementen = new[]
            {
                new AbonnementModel { Type = "Free", MaximaleItems = 1, Uitleentermijn = 21, Verlengingen = 3, Reserveringskosten = 0.00, Boetekosten = 0.00, Abonnementskosten = 0.00 },
                new AbonnementModel { Type = "Jeugd", MaximaleItems = -1, Uitleentermijn = 21, Verlengingen = 3, Reserveringskosten = 0.25, Boetekosten = 0.00, Abonnementskosten = 5.00 },
                new AbonnementModel { Type = "Budget", MaximaleItems = 10, Uitleentermijn = 21, Verlengingen = 1, Reserveringskosten = 0.25, Boetekosten = 0.30, Abonnementskosten = 10.00 },
                new AbonnementModel { Type = "Basis", MaximaleItems = -1, Uitleentermijn = 21, Verlengingen = 3, Reserveringskosten = 0.25, Boetekosten = 0.30, Abonnementskosten = 15.00 }
            };

            context.Abonnementen.AddRange(abonnementen);
            context.SaveChanges();
        }
    }

    private static void SeedLocations(ApplicationDbContext context)
    {
        // Check if Locations already exist
        if (!context.Locaties.Any())
        {
            var locaties = new[]
            {
            new LocatieModel { Beschrijving = "Noord" },
            new LocatieModel { Beschrijving = "Oost" },
            new LocatieModel { Beschrijving = "West" },
            new LocatieModel { Beschrijving = "Zuid" }
        };

            context.Locaties.AddRange(locaties);
            context.SaveChanges();
        }
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
