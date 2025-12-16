using Gerenciador.Credito.Domain.Entities;

namespace Gerenciador.Credito.Domain.Interfaces;

public interface ICreditoRepository
{
    Task AddAsync(CreditoEntity credito);
    Task<bool> ExistsAsync(string numeroCredito);
    Task<CreditoEntity?> GetByNumeroCreditoAsync(string numeroCredito);
    Task<IEnumerable<CreditoEntity>> GetByNumeroNfseAsync(string numeroNfse);
}
