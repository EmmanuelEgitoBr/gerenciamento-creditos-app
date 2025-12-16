using Gerenciador.Credito.Application.Models.Queries;
using MediatR;

namespace Gerenciador.Credito.Application.Queries.GetCreditosByNfse;

public class GetCreditosByNfseQuery : IRequest<IEnumerable<CreditoConstituidoResult>>
{
    public string NumeroNfse { get; set; }
}
