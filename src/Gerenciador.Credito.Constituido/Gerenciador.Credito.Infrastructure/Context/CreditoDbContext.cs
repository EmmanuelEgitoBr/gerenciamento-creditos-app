using Gerenciador.Credito.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Entidade = Gerenciador.Credito.Domain.Entities;

namespace Gerenciador.Credito.Infrastructure.Context;

public class CreditoDbContext : DbContext
{
    public DbSet<Entidade.Credito> Creditos => Set<Entidade.Credito>();


    public CreditoDbContext(DbContextOptions<CreditoDbContext> options)
    : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CreditoConfiguration());
    }
}
