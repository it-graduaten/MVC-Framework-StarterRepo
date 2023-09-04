using Microsoft.EntityFrameworkCore;

using _09_00_HelloCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace _09_00_HelloCore.Data

{
    public class HelloCoreContext : IdentityDbContext<CustomUser>
    {
        public HelloCoreContext(DbContextOptions<HelloCoreContext> options) : base(options) { }

        public DbSet<Klant> Klanten { get; set; } = default!;
        public DbSet<Product> Producten { get; set; } = default!;
        public DbSet<Bestelling> Bestellingen { get; set; } = default!;
        public DbSet<OrderLijn> Orderlijnen { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Klant>().ToTable("Klant");
            modelBuilder.Entity<OrderLijn>().ToTable("OrderLijn");
            modelBuilder.Entity<Product>().ToTable("Product").Property(p => p.Prijs).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Bestelling>().ToTable("Bestelling");

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
