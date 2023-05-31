using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazorWasmHostedMudBlazorGraphqlTemplate.Domain;
public class SampleContext : DbContext
{
    private readonly ILoggerFactory _loggerFactory;

    public SampleContext(DbContextOptions options, ILoggerFactory loggerFactory) : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    public DbSet<Order> Orders { get; private set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseLoggerFactory(_loggerFactory);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        if (Database.IsInMemory())
        {
            modelBuilder.Entity<Order>().HasData(new[]
            {
                new Order(Guid.NewGuid(), "Soap", 3.99m, "Seed"),
                new Order(Guid.NewGuid(), "Tissues", 10.43m, "Seed"),
                new Order(Guid.NewGuid(), "Toothpaste", 8.67m, "Seed"),
            });
        }
    }
}
