using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.Serialization;

namespace Gerenciador.Credito.Application.Models.Commands;

public sealed class IntegrarCreditoContract
{
    [DataMember]
    [BindingBehavior(BindingBehavior.Required)]
    public string NumeroCredito { get; set; }
    
    [DataMember]
    [BindingBehavior(BindingBehavior.Required)]
    public string NumeroNfse { get; set; }
    public DateTime DataConstituicao { get; set; }
    public decimal ValorIssqn { get; set; }
    
    [DataMember]
    [BindingBehavior(BindingBehavior.Required)]
    public string TipoCredito { get; set; }
    public bool SimplesNacional { get; set; }
    public decimal Aliquota { get; set; }
    public decimal ValorFaturado { get; set; }
    public decimal ValorDeducao { get; set; }
    public decimal BaseCalculo { get; set; }
}
