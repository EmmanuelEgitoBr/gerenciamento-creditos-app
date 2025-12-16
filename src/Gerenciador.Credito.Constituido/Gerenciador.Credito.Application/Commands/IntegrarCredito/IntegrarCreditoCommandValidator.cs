using FluentValidation;

namespace Gerenciador.Credito.Application.Commands.IntegrarCredito;

public class IntegrarCreditoCommandValidator : AbstractValidator<IntegrarCreditoCommand>
{
    public IntegrarCreditoCommandValidator()
    {
        RuleFor(x => x.Creditos).NotEmpty();
    }
}
