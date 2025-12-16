using Gerenciador.Credito.Application.Models.Commands;
using MediatR;

namespace Gerenciador.Credito.Application.Commands.IntegrarCredito;

public record IntegrarCreditoCommand : IRequest<IntegrarCreditoCommandResult>
{
    public IEnumerable<IntegrarCreditoContract> Creditos { get; set; }
}
