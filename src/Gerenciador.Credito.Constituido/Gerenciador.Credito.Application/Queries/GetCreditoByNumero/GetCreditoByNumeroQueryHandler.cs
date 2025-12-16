using Gerenciador.Credito.Application.Models.Queries;
using Gerenciador.Credito.Domain.Entities;
using Gerenciador.Credito.Domain.Interfaces;
using MediatR;

namespace Gerenciador.Credito.Application.Queries.GetCreditoByNumero;

public class GetCreditoByNumeroQueryHandler : IRequestHandler<GetCreditoByNumeroQuery, CreditoConstituidoResult>
{
    private readonly ICreditoRepository _creditoRepository;

    public GetCreditoByNumeroQueryHandler(ICreditoRepository creditoRepository)
    {
        _creditoRepository = creditoRepository;
    }

    public async Task<CreditoConstituidoResult> Handle(GetCreditoByNumeroQuery request, CancellationToken cancellationToken)
    {
        var creditoEntity = await _creditoRepository.GetByNumeroCreditoAsync(request.NumeroCredito);
        return ControiCreditoConstituido(creditoEntity!);
    }

    private CreditoConstituidoResult ControiCreditoConstituido(
        CreditoEntity creditoEntity)
    {
            return new CreditoConstituidoResult
            {
                NumeroCredito = creditoEntity.NumeroCredito,
                NumeroNfse = creditoEntity.NumeroNfse,
                DataConstituicao = creditoEntity.DataConstituicao,
                ValorIssqn = creditoEntity.ValorIssqn,
                TipoCredito = creditoEntity.TipoCredito,
                SimplesNacional = creditoEntity.SimplesNacional,
                Aliquota = creditoEntity.Aliquota,
                ValorFaturado = creditoEntity.ValorFaturado,
                ValorDeducao = creditoEntity.ValorDeducao,
                BaseCalculo = creditoEntity.BaseCalculo
            };
    }
}
