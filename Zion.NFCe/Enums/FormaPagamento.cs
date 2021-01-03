using System.ComponentModel;
using System.Xml.Serialization;

namespace Zion.NFCe.Enums
{
    public enum FormaPagamento
    {
        [Description("Dinheiro")]
        [XmlEnum("01")]
        Dinheiro = 01,

        [Description("Cheque")]
        [XmlEnum("02")]
        Cheque = 02,

        [Description("Cartão de Crédito")]
        [XmlEnum("03")]
        CartaoCredito = 03,

        [Description("Cartão de Débito")]
        [XmlEnum("04")]
        CartaoDebito = 04,

        [Description("Crédito Loja")]
        [XmlEnum("05")]
        CreditoLoja = 05,

        [Description("Vale Alimentação")]
        [XmlEnum("10")]
        ValeAlimentacao = 10,

        [Description("Vale Refeição")]
        [XmlEnum("11")]
        ValeRefeicao = 11,

        [Description("Vale Presente")]
        [XmlEnum("12")]
        ValePresente = 12,

        [Description("Vale Combustível")]
        [XmlEnum("13")]
        ValeCombustivel = 13,

        [Description("Duplicata Mercantil")]
        [XmlEnum("14")]
        DuplicataMercantil = 14,

        [Description("Boleto Bancário")]
        [XmlEnum("15")]
        BoletoBancario = 15,

        [Description("Sem pagamento")]
        [XmlEnum("90")]
        SemPagamento = 90,

        [Description("Outros")]
        [XmlEnum("99")]
        Outro = 99
    }
}
