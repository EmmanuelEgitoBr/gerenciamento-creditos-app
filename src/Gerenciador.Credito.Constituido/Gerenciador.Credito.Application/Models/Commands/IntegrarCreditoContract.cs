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

    [DataMember]
    [BindingBehavior(BindingBehavior.Required)]
    public DateTime DataConstituicao { get; set; }

    [DataMember]
    [BindingBehavior(BindingBehavior.Required)]
    public decimal ValorIssqn { get; set; }
    
    [DataMember]
    [BindingBehavior(BindingBehavior.Required)]
    public string TipoCredito { get; set; }

    [DataMember]
    [BindingBehavior(BindingBehavior.Required)]
    public bool SimplesNacional { get; set; }

    [DataMember]
    [BindingBehavior(BindingBehavior.Required)]
    public decimal Aliquota { get; set; }

    [DataMember]
    [BindingBehavior(BindingBehavior.Required)]
    public decimal ValorFaturado { get; set; }

    [DataMember]
    [BindingBehavior(BindingBehavior.Required)]
    public decimal ValorDeducao { get; set; }

    [DataMember]
    [BindingBehavior(BindingBehavior.Required)]
    public decimal BaseCalculo { get; set; }
}
