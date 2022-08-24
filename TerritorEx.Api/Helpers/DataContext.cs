using Microsoft.EntityFrameworkCore;
using TerritorEx.Api.Entities;

namespace TerritorEx.Api.Helpers;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Connect to sql server with connection string from app settings
       options.UseSqlServer(Configuration.GetConnectionString("ApiDatabase"), 
           x => x.UseNetTopologySuite());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Disable cascade delete in foreign keys
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Levels> Levels { get; set; }
    public DbSet<Territories> Territories { get; set; }
}