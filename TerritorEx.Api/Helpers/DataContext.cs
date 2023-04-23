using Microsoft.EntityFrameworkCore;
using TerritorEx.Api.Entities;

namespace TerritorEx.Api.Helpers;

public class DataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("TerritorEx"));
    }

    public DbSet<Usuario> Usuario { get; set; }
}