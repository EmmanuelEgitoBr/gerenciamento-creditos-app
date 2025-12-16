using Gerenciador.Credito.Domain.Entities;
using Gerenciador.Credito.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Credito.Infrastructure.Context;

public class CreditoDbContext : DbContext
{
    public DbSet<CreditoEntity> Creditos => Set<CreditoEntity>();


    public CreditoDbContext(DbContextOptions<CreditoDbContext> options)
    : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CreditoConfiguration());
    }
}
