using FluentValidation;

namespace Gerenciador.Credito.Application.Queries.GetCreditosByNfse;

public class GetCreditosByNfseQueryValidator : AbstractValidator<GetCreditosByNfseQuery>
{
    public GetCreditosByNfseQueryValidator()
    {
        RuleFor(x => x.NumeroNfse).NotEmpty().WithMessage("O número da NFS-e é obrigatório.");
    }
}
