using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class DataContext: DbContext
{
    public DbSet<Device> Devices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=localhost:5432;Username=postgres;Password=root;Database=demo-api-db");
}