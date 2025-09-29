using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Crypto> Cryptos { get; set; }
    public DbSet<PriceAlert> PriceAlerts { get; set; }
    public DbSet<PriceHistory> PriceHistories { get; set; }
}
