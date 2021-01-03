using System.ComponentModel;
using System.Xml.Serialization;

namespace Zion.NFCe.Enums
{
    public enum BandeiraCartao
    {
        [Description("Visa")]
        [XmlEnum("1")]
        Visa = 1,
        [Description("Mastercard")]
        [XmlEnum("2")]
        MasterCard = 2,
        [Description("American Express")]
        [XmlEnum("3")]
        AmericanExpress = 3,
        [Description("Soro")]
        [XmlEnum("4")]
        Sorocred = 4,
        [Description("Diners Club")]
        [XmlEnum("5")]
        DinersClub = 5,
        [Description("Elo")]
        [XmlEnum("6")]
        Elo = 6,
        [Description("HiperCard")]
        [XmlEnum("7")]
        Hipercard = 7,
        [Description("Aura")]
        [XmlEnum("8")]
        Aura = 8,
        [Description("Cabal")]
        [XmlEnum("9")]
        Cabal = 9,
        [Description("Outros")]
        [XmlEnum("99")]
        bcOutros = 99
    }
}
