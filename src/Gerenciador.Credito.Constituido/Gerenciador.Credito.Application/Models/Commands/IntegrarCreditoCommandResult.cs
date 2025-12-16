using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador.Credito.Application.Models.Commands
{
    public sealed class IntegrarCreditoCommandResult
    {
        public int StatusCode { get; set; }
        public bool Sucesso { get; set; }
    }
}
