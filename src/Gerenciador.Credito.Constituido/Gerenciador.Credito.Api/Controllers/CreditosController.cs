using Gerenciador.Credito.Application.Commands.IntegrarCredito;
using Gerenciador.Credito.Application.Models.Commands;
using Gerenciador.Credito.Application.Models.Queries;
using Gerenciador.Credito.Application.Queries.GetCreditoByNumero;
using Gerenciador.Credito.Application.Queries.GetCreditosByNfse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gerenciador.Credito.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreditosController(IMediator mediator)
        => _mediator = mediator;

        [HttpPost("integrar-credito-constituido")]
        [ProducesResponseType(typeof(IntegrarCreditoCommandResult), (int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> Post(List<IntegrarCreditoCommand> commands)
        {
            foreach (var cmd in commands)
                await _mediator.Send(cmd);


            return Accepted(new { success = true });
        }

        [HttpGet("{numeroNfse}")]
        [ProducesResponseType(typeof(CreditoConstituidoResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CreditoConstituidoResult), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByNfse(string numeroNfse)
        => Ok(await _mediator.Send(new GetCreditosByNfseQuery { NumeroNfse = numeroNfse}));


        [HttpGet("credito/{numeroCredito}")]
        [ProducesResponseType(typeof(CreditoConstituidoResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(CreditoConstituidoResult), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetByCredito(string numeroCredito)
        => Ok(await _mediator.Send(new GetCreditoByNumeroQuery { NumeroCredito = numeroCredito}));
    }
}
