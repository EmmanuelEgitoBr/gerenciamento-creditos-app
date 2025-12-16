using FluentValidation;

namespace Gerenciador.Credito.Application.Queries.GetCreditoByNumero
{
    public class GetCreditoByNumeroQueryValidator : AbstractValidator<GetCreditoByNumeroQuery>
    {
        public GetCreditoByNumeroQueryValidator()
        {
            RuleFor(x => x.NumeroCredito).NotEmpty().WithMessage("O número do crédito é obrigatório.");
        }
    }
}
