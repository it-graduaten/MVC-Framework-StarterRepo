using Microsoft.EntityFrameworkCore;

using HelloCore.Models;

namespace HelloCore.Data

{
    public class HelloCoreContext : DbContext
    {
        public HelloCoreContext(DbContextOptions<HelloCoreContext> options) : base(options) { }

        public DbSet<Klant> Klanten { get; set; } = default!;
        public DbSet<Product> Producten { get; set; } = default!;
        public DbSet<Categorie> Categorieën { get; set; } = default!;
        public DbSet<Bestelling> Bestellingen { get; set; } = default!;
        public DbSet<OrderLijn> Orderlijnen { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Klant>().ToTable("Klant");
            modelBuilder.Entity<Product>().ToTable("Product").Property(p => p.Prijs).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Categorie>().ToTable("Categorie");
            modelBuilder.Entity<Bestelling>().ToTable("Bestelling");
            modelBuilder.Entity<OrderLijn>().ToTable("OrderLijn");

            modelBuilder.Entity<Bestelling>()
                .HasOne(p => p.klant)
                .WithMany(x => x.bestelling)
                .HasForeignKey(y => y.KlantID)
                .IsRequired();

            modelBuilder.Entity<OrderLijn>()
                .HasOne(p => p.product)
                .WithMany(x => x.orderlijnen)
                .HasForeignKey(y => y.ProductID)
                .IsRequired();
        }
    }


}
