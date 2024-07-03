using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ApplicationDbContext : DbContext
{
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>()
            .HasMany(g => g.Books)
            .WithOne(b => b.Genre)
            .HasForeignKey(b => b.GenreId);

        base.OnModelCreating(modelBuilder);
    }
}
