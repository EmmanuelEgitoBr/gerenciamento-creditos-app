using Gerenciador.Credito.Application.Models.Queries;
using Gerenciador.Credito.Domain.Entities;
using Gerenciador.Credito.Domain.Interfaces;
using MediatR;

namespace Gerenciador.Credito.Application.Queries.GetCreditosByNfse;

public class GetCreditosByNfseQueryHandler : IRequestHandler<GetCreditosByNfseQuery, IEnumerable<CreditoConstituidoResult>>
{
    private readonly ICreditoRepository _creditoRepository;

    public GetCreditosByNfseQueryHandler(ICreditoRepository creditoRepository)
    {
        _creditoRepository = creditoRepository;
    }

    public async Task<IEnumerable<CreditoConstituidoResult>> Handle(GetCreditosByNfseQuery request, CancellationToken cancellationToken)
    {
        var creditosEntity = await _creditoRepository.GetByNumeroNfseAsync(request.NumeroNfse);

        return ControiListaCreditos(creditosEntity);
    }
    
    private IEnumerable<CreditoConstituidoResult> ControiListaCreditos(
        IEnumerable<CreditoEntity> creditosEntity)
    {
        List<CreditoConstituidoResult> listaCreditos = new List<CreditoConstituidoResult>();

        foreach (var creditoEntity in creditosEntity)
        {
            var credito = new CreditoConstituidoResult
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
            listaCreditos.Add(credito);
        }
        return listaCreditos;
    }
    
}
