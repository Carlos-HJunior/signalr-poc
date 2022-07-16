using Microsoft.EntityFrameworkCore;
using signalr_poc.Domain.Entities;

namespace signalr_poc.Domain;

public class PocDbContext : DbContext
{
    public PocDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Dummy> Dummies { get; set; }
}