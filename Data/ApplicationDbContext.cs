using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Bogus;
using System.Collections.Generic;
using MVCLibraryApp.Models;

namespace MVCLibraryApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<VisitorModel>
    {
        // Constructor accepting DbContextOptions<ApplicationDbContext>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<VisitorModel> Bezoekers { get; set; }
        public DbSet<EmployeeModel> Medewerkers { get; set; }
        public DbSet<AuthorModel> Auteurs { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<LocationModel> Locaties { get; set; }
        public DbSet<AbonnementModel> Abonnementen { get; set; }
        public DbSet<LoanModel> Lenings { get; set; }
        public DbSet<ReservationModel> Reserveringen { get; set; }
        public DbSet<MoneyBank> Geldbank { get; set; }
        public DbSet<InvoiceModel> Invoice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VisitorModel>()
                .HasOne(b => b.Abonnement)
                .WithMany(a => a.Visitors)
                .HasForeignKey(b => b.AbonnementID);

            modelBuilder.Entity<ItemModel>()
                .HasOne(i => i.Location)
                .WithMany(l => l.Items)
                .HasForeignKey(i => i.LocationID);

            modelBuilder.Entity<LoanModel>()
                .HasOne(l => l.Visitor)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.VisitorID);

            modelBuilder.Entity<LoanModel>()
                .HasOne(l => l.Item)
                .WithMany(i => i.Loans)
                .HasForeignKey(l => l.ItemID);

            modelBuilder.Entity<ReservationModel>()
                .HasOne(r => r.Visitor)
                .WithMany(b => b.Reservations)
                .HasForeignKey(r => r.VisitorID);

            modelBuilder.Entity<ReservationModel>()
                .HasOne(r => r.Item)
                .WithMany(i => i.Reservations)
                .HasForeignKey(r => r.ItemID);

            modelBuilder.Entity<ItemModel>()
                .HasOne(i => i.Author)
                .WithMany(a => a.Items)
                .HasForeignKey(i => i.AuthorID);


            modelBuilder.Entity<AbonnementModel>()
       .Property(a => a.AbonnementsCosts)
       .HasPrecision(10, 2); // Precision: 10, Scale: 2

            modelBuilder.Entity<AbonnementModel>()
                .Property(a => a.FineCosts)
                .HasPrecision(10, 2);

            modelBuilder.Entity<AbonnementModel>()
                .Property(a => a.ReservationCosts)
                .HasPrecision(10, 2);

            modelBuilder.Entity<InvoiceModel>()
                .Property(f => f.Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MoneyBank>()
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
        new AbonnementModel { ID = 1, Type = "Free", MaxItems = 10, ReturnTerm = 21, ProlongedTerm = 3, ReservationCosts = 0.50M, FineCosts = 0.50M, AbonnementsCosts = 0.00M },
        new AbonnementModel { ID = 2, Type = "Jeugd", MaxItems = 10, ReturnTerm = 21, ProlongedTerm = 3, ReservationCosts = 0.25M, FineCosts = 0.00M, AbonnementsCosts = 0.00M },
        new AbonnementModel { ID = 3, Type = "Budget", MaxItems = 10, ReturnTerm = 21, ProlongedTerm = 1, ReservationCosts = 0.25M, FineCosts = 0.30M, AbonnementsCosts = 1.00M },
        new AbonnementModel { ID = 4, Type = "Basis", MaxItems = 10, ReturnTerm = 21, ProlongedTerm = 3, ReservationCosts = 0.25M, FineCosts = 0.30M, AbonnementsCosts = 4.00M },
        new AbonnementModel { ID = 5, Type = "Top", MaxItems = 10, ReturnTerm = 21, ProlongedTerm = 5, ReservationCosts = 0.00M, FineCosts = 0.00M, AbonnementsCosts = 6.00M }
    };

            builder.Entity<AbonnementModel>().HasData(abonnementen);
        }

        private void SeedLocations(ModelBuilder builder)
        {
            var locaties = new[]
            {
        new LocationModel { ID = 1, LocationName = "Noord" },
        new LocationModel { ID = 2, LocationName = "Oost" },
        new LocationModel { ID = 3, LocationName = "West" },
        new LocationModel { ID = 4, LocationName = "Zuid" }
    };

            builder.Entity<LocationModel>().HasData(locaties);
        }

        private void SeedAuteurs(ModelBuilder builder)
        {
            var faker = new Faker();

            var auteurs = Enumerable.Range(1, 100).Select(index => new AuthorModel
            {
                ID = index,
                Name = faker.Name.FullName(),
                Bio = faker.Lorem.Paragraph()
            }).ToArray();

            builder.Entity<AuthorModel>().HasData(auteurs);
        }


        private void SeedItems(ModelBuilder builder)
        {
            var faker = new Faker();

            var items = Enumerable.Range(1, 100).Select(index => new ItemModel
            {
                ID = index,
                Title = faker.Lorem.Sentence(3),
                AuthorID = faker.Random.Int(1, 100),
                PublicationYear = faker.Random.Int(1980, 2023),
                Status = "Available",
                LocationID = faker.Random.Int(1, 4) // Assign a random location ID between 1 and 4
            }).ToArray();

            builder.Entity<ItemModel>().HasData(items);
        }
        private void SeedGeldbank(ModelBuilder builder)
        {
            var Geldbank = Enumerable.Range(1, 1).Select(index => new MoneyBank
            {
                ID = index,
                TotalEarnings = 0m
            });
            builder.Entity<MoneyBank>().HasData(Geldbank);

        }



    }
}
