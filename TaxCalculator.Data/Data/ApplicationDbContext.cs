using Microsoft.EntityFrameworkCore;
using TaxCalculator.Domain;

namespace TaxCalculator.Persistence.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Pass> Passes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>().HasKey(v => v.Id);
        modelBuilder.Entity<Pass>().HasKey(p => p.Id);
        modelBuilder.Entity<Pass>()
                    .HasOne(p => p.Vehicle)
                    .WithMany()
                    .HasForeignKey(p => p.VehicleId);
    }
}
