using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Bogus;
using System.Collections.Generic;

namespace MVCLibraryApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<BezoekerModel>
    {
        // Constructor accepting DbContextOptions<ApplicationDbContext>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BezoekerModel> Bezoekers { get; set; }
        public DbSet<MedewerkerModel> Medewerkers { get; set; }
        public DbSet<AuteurModel> Auteurs { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<LocatieModel> Locaties { get; set; }
        public DbSet<AbonnementModel> Abonnementen { get; set; }
        public DbSet<LeningModel> Lenings { get; set; }
        public DbSet<ReserveringModel> Reserveringen { get; set; }
        public DbSet<GeldbankModel> Geldbank { get; set; }
        public DbSet<FactuurModel> Facturen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    //       base.OnModelCreating(modelBuilder);

    //var hasher = new PasswordHasher<IdentityUser>();

    //modelBuilder.Entity<IdentityRole>().HasData(
    //    new IdentityRole { Id = "1", Name = "Bezoeker", NormalizedName = "BEZOEKER" },
    //    new IdentityRole { Id = "2", Name = "Medewerker", NormalizedName = "MEDEWERKER" },
    //    new IdentityRole { Id = "3", Name = "Beheerder", NormalizedName = "BEHEERDER" }
    //);

    //// Use a GUID for the user's Id.
    //string adminId = Guid.NewGuid().ToString();

    //modelBuilder.Entity<IdentityUser>().HasData(
    //    new IdentityUser
    //    {
    //        Id = adminId,
    //        UserName = "admin@example.com",
    //        NormalizedUserName = "ADMIN@EXAMPLE.COM",
    //        Email = "admin@example.com",
    //        NormalizedEmail = "ADMIN@EXAMPLE.COM",
    //        EmailConfirmed = true,
    //        PasswordHash = hasher.HashPassword(null, "Password123!"),
    //        SecurityStamp = string.Empty,
    //    });

    // modelBuilder.Entity<IdentityUserRole<string>>().HasData(
    //    new IdentityUserRole<string>
    //    {
    //        RoleId = "3", 
    //        UserId = adminId
    //    });


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BezoekerModel>()
                .HasOne(b => b.Abonnement)
                .WithMany(a => a.Bezoekers)
                .HasForeignKey(b => b.AbonnementID);

            modelBuilder.Entity<ItemModel>()
                .HasOne(i => i.Locatie)
                .WithMany(l => l.Items)
                .HasForeignKey(i => i.LocatieID);

            modelBuilder.Entity<LeningModel>()
                .HasOne(l => l.Bezoeker)
                .WithMany(b => b.Lenings)
                .HasForeignKey(l => l.BezoekerID);

            modelBuilder.Entity<LeningModel>()
                .HasOne(l => l.Item)
                .WithMany(i => i.Lenings)
                .HasForeignKey(l => l.ItemID);

            modelBuilder.Entity<ReserveringModel>()
                .HasOne(r => r.Bezoeker)
                .WithMany(b => b.Reserverings)
                .HasForeignKey(r => r.BezoekerID);

            modelBuilder.Entity<ReserveringModel>()
                .HasOne(r => r.Item)
                .WithMany(i => i.Reserverings)
                .HasForeignKey(r => r.ItemID);

            modelBuilder.Entity<ItemModel>()
                .HasOne(i => i.Auteur)
                .WithMany(a => a.Items)
                .HasForeignKey(i => i.AuteurID);


            modelBuilder.Entity<AbonnementModel>()
       .Property(a => a.Abonnementskosten)
       .HasPrecision(10, 2); // Precision: 10, Scale: 2

            modelBuilder.Entity<AbonnementModel>()
                .Property(a => a.Boetekosten)
                .HasPrecision(10, 2);

            modelBuilder.Entity<AbonnementModel>()
                .Property(a => a.Reserveringskosten)
                .HasPrecision(10, 2);

            modelBuilder.Entity<FactuurModel>()
                .Property(f => f.Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<GeldbankModel>()
                .Property(g => g.TotalEarnings)
                .HasPrecision(10, 2);

            SeedAbonnementen(modelBuilder);
            SeedLocations(modelBuilder);
            SeedAuteurs(modelBuilder);
            SeedItems(modelBuilder);
            SeedGeldbank(modelBuilder);
        }

        private void SeedAbonnementen(ModelBuilder builder)
        {
            var abonnementen = new[]
            {
        new AbonnementModel { ID = -1, Type = "Free", MaximaleItems = 1, Uitleentermijn = 21, Verlengingen = 3, Reserveringskosten = 0.00M, Boetekosten = 0.00M, Abonnementskosten = 0.00M },
        new AbonnementModel { ID = -2, Type = "Jeugd", MaximaleItems = -1, Uitleentermijn = 21, Verlengingen = 3, Reserveringskosten = 0.25M, Boetekosten = 0.00M, Abonnementskosten = 5.00M },
        new AbonnementModel { ID = -3, Type = "Budget", MaximaleItems = 10, Uitleentermijn = 21, Verlengingen = 1, Reserveringskosten = 0.25M, Boetekosten = 0.30M, Abonnementskosten = 10.00M },
        new AbonnementModel { ID = -4, Type = "Basis", MaximaleItems = -1, Uitleentermijn = 21, Verlengingen = 3, Reserveringskosten = 0.25M, Boetekosten = 0.30M, Abonnementskosten = 15.00M }
    };

            builder.Entity<AbonnementModel>().HasData(abonnementen);
        }


        private void SeedLocations(ModelBuilder builder)
        {
            var locaties = new[]
            {
        new LocatieModel { ID = 1, Beschrijving = "Noord" },
        new LocatieModel { ID = 2, Beschrijving = "Oost" },
        new LocatieModel { ID = 3, Beschrijving = "West" },
        new LocatieModel { ID = 4, Beschrijving = "Zuid" }
    };

            builder.Entity<LocatieModel>().HasData(locaties);
        }

        private void SeedAuteurs(ModelBuilder builder)
        {
            var faker = new Bogus.Faker();

            var auteurs = Enumerable.Range(1, 100).Select(index => new AuteurModel
            {
                ID = index,
                Name = faker.Name.FullName(),
                Bio = faker.Lorem.Paragraph()
            }).ToArray();

            builder.Entity<AuteurModel>().HasData(auteurs);
        }


        private void SeedItems(ModelBuilder builder)
        {
            var faker = new Bogus.Faker();

            var items = Enumerable.Range(1, 100).Select(index => new ItemModel
            {
                ID = index,
                Titel = faker.Lorem.Sentence(3),
                AuteurID = faker.Random.Int(1, 100),
                Publicatiejaar = faker.Random.Int(1980, 2023),
                Status = "Available",
                LocatieID = faker.Random.Int(1, 4) // Assign a random location ID between 1 and 4
            }).ToArray();

            builder.Entity<ItemModel>().HasData(items);
        }
        private void SeedGeldbank(ModelBuilder builder)
        {
            var Geldbank = Enumerable.Range(1, 1).Select(index => new GeldbankModel
            {
                ID = index,
                TotalEarnings = 0m
            });
            builder.Entity<GeldbankModel>().HasData(Geldbank);

        }



    }
}
