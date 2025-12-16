using Gerenciador.Credito.Domain.Entities;
using Gerenciador.Credito.Domain.Interfaces;
using Gerenciador.Credito.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Credito.Infrastructure.Repositories;

public class CreditoRepository : ICreditoRepository
{
    private readonly CreditoDbContext _context;

    public CreditoRepository(CreditoDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(CreditoEntity credito)
    {
        _context.Creditos.Add(credito);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(string numeroCredito)
    {
        return await _context.Creditos
            .AsNoTracking()
            .AnyAsync(c => c.NumeroCredito == numeroCredito);
    }

    public async Task<CreditoEntity?> GetByNumeroCreditoAsync(string numeroCredito)
    {
        return await _context.Creditos
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.NumeroCredito == numeroCredito);
    }

    public async Task<IEnumerable<CreditoEntity>> GetByNumeroNfseAsync(string numeroNfse)
    {
        return await _context.Creditos
            .AsNoTracking()
            .Where(c => c.NumeroNfse == numeroNfse)
            .OrderBy(c => c.DataConstituicao)
            .ToListAsync();
    }
}
