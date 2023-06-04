using Microsoft.EntityFrameworkCore;
using ShopApp.Domain.Entities;

namespace ShopApp.Infrastructure
{
  public class DbAppContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<RegionPoint> RegionPoints { get; set; }
    public DbSet<DeliveryAdress> DeliveryAdresses { get; set; }
    public DbSet<ShopPoint> ShopPoints { get; set; }
    public DbSet<ProductShopPoint> ProductShopPoints { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductComment> ProductComments { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }

    public DbAppContext(DbContextOptions<DbAppContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Product>()
        .HasOne(e => e.Manufacturer)
        .WithMany()
        .HasForeignKey(e => e.ManufacturerId);

      modelBuilder.Entity<Product>()
        .HasMany(e => e.ProductComments)
        .WithOne()
        .HasForeignKey(e => e.ProductId);

      modelBuilder.Entity<ProductShopPoint>()
        .HasOne(e => e.Product)
        .WithMany()
        .HasForeignKey(e=> e.ProductId);

      modelBuilder.Entity<ProductShopPoint>()
        .HasOne(e => e.ShopPoint)
        .WithMany()
        .HasForeignKey(e=> e.ShopPointId);

      modelBuilder.Entity<ProductComment>()
        .HasOne(e => e.User)
        .WithMany()
        .HasForeignKey(e => e.UserId);

      modelBuilder.Entity<Order>()
        .HasOne(e => e.User)
        .WithMany()
        .HasForeignKey(e => e.UserId);

      modelBuilder.Entity<Order>()
        .HasMany(e => e.Products)
         .WithOne()
         .HasForeignKey(e => e.ProductId);

      modelBuilder.Entity<Order>()
        .HasOne(e => e.ShopPoint)
        .WithMany()
        .HasForeignKey(e => e.ShopPointId);

      modelBuilder.Entity<Order>()
        .HasOne(e => e.DeliveryAdress)
        .WithMany()
        .HasForeignKey(e => e.DeliveryAdressId);

      base.OnModelCreating(modelBuilder);
    }
  }
}
