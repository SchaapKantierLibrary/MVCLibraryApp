using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCLibraryApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<BezoekerModel>
    {
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            // Call the seed method
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Abonnementen
            modelBuilder.Entity<AbonnementModel>().HasData(
                new AbonnementModel
                {
                    ID = -1,
                    Type = "Free",
                    MaximaleItems = 1,
                    Uitleentermijn = 21,
                    Verlengingen = 3,
                    Reserveringskosten = 0.00,
                    Boetekosten = 0.00,
                    Abonnementskosten = 0.00
                },
                new AbonnementModel
                {
                    ID = -2,
                    Type = "Jeugd",
                    MaximaleItems = -1,
                    Uitleentermijn = 21,
                    Verlengingen = 3,
                    Reserveringskosten = 0.25,
                    Boetekosten = 0.00,
                    Abonnementskosten = 5.00
                },
                new AbonnementModel
                {
                    ID = -3,
                    Type = "Budget",
                    MaximaleItems = 10,
                    Uitleentermijn = 21,
                    Verlengingen = 1,
                    Reserveringskosten = 0.25,
                    Boetekosten = 0.30,
                    Abonnementskosten = 10.00
                },
                new AbonnementModel
                {
                    ID = -4,
                    Type = "Basis",
                    MaximaleItems = -1,
                    Uitleentermijn = 21,
                    Verlengingen = 3,
                    Reserveringskosten = 0.25,
                    Boetekosten = 0.30,
                    Abonnementskosten = 15.00
                }
            );

            // Seed Locations
            modelBuilder.Entity<LocatieModel>().HasData(
                new LocatieModel { Beschrijving = "Noord" },
                new LocatieModel { Beschrijving = "Oost" },
                new LocatieModel { Beschrijving = "West" },
                new LocatieModel { Beschrijving = "Zuid" }
            );

            var faker = new Bogus.Faker();
            for (int i = 1; i <= 100; i++)
            {
                modelBuilder.Entity<AuteurModel>().HasData(
                    new AuteurModel
                    {
                        ID = -i, // Use negative values for ID
                        Name = faker.Name.FullName(),
                        Bio = faker.Lorem.Paragraph()
                    }
                );
            }
        }
    }
}
