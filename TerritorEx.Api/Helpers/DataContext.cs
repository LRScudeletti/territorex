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
        options.UseSqlServer(Configuration.GetConnectionString("ApiDatabase"));
    }

    public DbSet<TerritoryEntity> Territories { get; set; }
}