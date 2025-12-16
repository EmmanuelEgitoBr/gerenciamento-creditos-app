using Gerenciador.Credito.Application.Models.Queries;
using MediatR;

namespace Gerenciador.Credito.Application.Queries.GetCreditoByNumero;

public class GetCreditoByNumeroQuery : IRequest<CreditoConstituidoResult>
{
    public string NumeroCredito { get; set; }
}
