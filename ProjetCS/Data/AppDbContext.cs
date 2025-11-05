using ProjetCS.Model;

namespace ProjetCS.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class AppDbContext : DbContext
{
    // Tables générées automatiquement par EF Core
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Cars> Cars { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public AppDbContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relation Classe -> Person (1..n)
        modelBuilder.Entity<Cars>()
            .HasOne(car => car.Customers)
            .WithMany(customer  => customer.Cars)
            .HasForeignKey(car => car.IdCustomer);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var pathProject = PathHelper.SolutionRootPath;
        // Charger la configuration manuellement
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile( // je ne comprends pas pourquoi ici je dois rajouter cette partie :/RiderProjects/ProjetCSHARP/ProjetCS
                          // pourtant dans Programs.cs pathPrject + "/appsettings.json" suffit
                pathProject  + "/appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
