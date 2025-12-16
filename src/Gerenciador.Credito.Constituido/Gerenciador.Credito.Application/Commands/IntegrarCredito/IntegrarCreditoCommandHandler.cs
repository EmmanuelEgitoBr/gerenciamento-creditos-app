using Gerenciador.Credito.Application.Models.Commands;
using Gerenciador.Credito.Domain.Entities;
using Gerenciador.Credito.Domain.Interfaces;
using MediatR;
using System.Net;

namespace Gerenciador.Credito.Application.Commands.IntegrarCredito
{
    public class IntegrarCreditoCommandHandler : IRequestHandler<IntegrarCreditoCommand, IntegrarCreditoCommandResult>
    {
        private readonly ICreditoRepository _creditoRepository;
        //private readonly IMessagePublisher _publisher;

        public IntegrarCreditoCommandHandler(ICreditoRepository creditoRepository
            //,IMessagePublisher publisher
            )
        {
            _creditoRepository = creditoRepository;
            //_publisher = publisher;
        }

        public async Task<IntegrarCreditoCommandResult> Handle(IntegrarCreditoCommand request, CancellationToken cancellationToken)
        {
            int quantidadeNovosRegistros = 0;

            foreach (var credito in request.Creditos)
            {
                var registroExisteNoBanco = await _creditoRepository.ExistsAsync(credito.NumeroCredito);
                if (!registroExisteNoBanco)
                {
                    var novoCredito = new CreditoEntity(
                        credito.NumeroCredito,
                        credito.NumeroNfse,
                        credito.DataConstituicao,
                        credito.ValorIssqn,
                        credito.TipoCredito,
                        credito.SimplesNacional,
                        credito.Aliquota,
                        credito.ValorFaturado,
                        credito.ValorDeducao,
                        credito.BaseCalculo);
                }
                //await _publisher.PublishAsync("integrar-credito-constituido-entry", novoCredito);
                quantidadeNovosRegistros++;
            }

            if (quantidadeNovosRegistros > 0)
                return new IntegrarCreditoCommandResult
                {
                    StatusCode = (int)HttpStatusCode.Accepted,
                    Sucesso = true
                };

            return new IntegrarCreditoCommandResult
            {
                StatusCode = (int)HttpStatusCode.NoContent,
                Sucesso = true
            };
        }
    }
}
