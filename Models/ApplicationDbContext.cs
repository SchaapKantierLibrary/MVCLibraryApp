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
        }
    }
}
