using Microsoft.EntityFrameworkCore;
using miniApi.Models.Domain;

namespace miniApi.Data;

public class DatabaseConnection : DbContext
{
    public DatabaseConnection(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
}