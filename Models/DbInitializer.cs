using Microsoft.AspNetCore.Identity;
using MVCLibraryApp.Models;
using System.Linq;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context, UserManager<BezoekerModel> userManager, RoleManager<IdentityRole> roleManager)
    {
        context.Database.EnsureCreated();

        // Seed roles
        SeedRoles(roleManager);

        // Seed Abonnementen
        SeedAbonnementen(context);

        // Seed users
        SeedUsersAndRoles(userManager, roleManager);
    }

    private static void SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        if (!roleManager.RoleExistsAsync("Bezoeker").Result)
        {
            IdentityRole role = new IdentityRole { Name = "Bezoeker" };
            IdentityResult result = roleManager.CreateAsync(role).Result;
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

            if (userManager.FindByNameAsync(userName).Result == null)
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
    }



}