namespace TerritorEx.Api.Helpers;

using Microsoft.EntityFrameworkCore;
using Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
    }

    public DbSet<TerritoryEntity> Territories { get; set; }
}