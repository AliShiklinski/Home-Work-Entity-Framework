using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ApplicationDbContext : DbContext
{
    private object options;

    public ApplicationDbContext(object options)
    {
        this.options = options;
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarColor> CarColors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarColor>()
            .HasKey(cc => new { cc.CarId, cc.ColorId });

        modelBuilder.Entity<CarColor>()
            .HasOne(cc => cc.Car)
            .WithMany(c => c.CarColors)
            .HasForeignKey(cc => cc.CarId);

        modelBuilder.Entity<CarColor>()
            .HasOne(cc => cc.Color)
            .WithMany(c => c.CarColors)
            .HasForeignKey(cc => cc.ColorId);

        modelBuilder.Entity<Model>()
            .HasOne(m => m.Brand)
            .WithMany(b => b.Models)
            .HasForeignKey(m => m.BrandId);

        modelBuilder.Entity<Car>()
            .HasOne(c => c.Model)
            .WithMany(m => m.Cars)
            .HasForeignKey(c => c.ModelId);
    }
}