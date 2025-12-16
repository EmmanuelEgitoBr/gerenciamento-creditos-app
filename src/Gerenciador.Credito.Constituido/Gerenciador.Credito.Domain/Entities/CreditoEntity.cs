namespace Gerenciador.Credito.Domain.Entities;

public class CreditoEntity
{
    public long Id { get; set; }
    public string NumeroCredito { get; private set; }
    public string NumeroNfse { get; private set; }
    public DateTime DataConstituicao { get; private set; }
    public decimal ValorIssqn { get; private set; }
    public string TipoCredito { get; private set; }
    public bool SimplesNacional { get; private set; }
    public decimal Aliquota { get; private set; }
    public decimal ValorFaturado { get; private set; }
    public decimal ValorDeducao { get; private set; }
    public decimal BaseCalculo { get; private set; }

    public CreditoEntity(string numeroCredito, string numeroNfse, DateTime data,
    decimal valorIssqn, string tipoCredito, bool simples,
    decimal aliquota, decimal faturado, decimal deducao, decimal baseCalculo)
    {
        NumeroCredito = numeroCredito;
        NumeroNfse = numeroNfse;
        DataConstituicao = data;
        ValorIssqn = valorIssqn;
        TipoCredito = tipoCredito;
        SimplesNacional = simples;
        Aliquota = aliquota;
        ValorFaturado = faturado;
        ValorDeducao = deducao;
        BaseCalculo = baseCalculo;
    }
}
