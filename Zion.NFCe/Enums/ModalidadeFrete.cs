using System.ComponentModel;
using System.Xml.Serialization;

namespace Zion.NFCe.Enums
{
    public enum ModalidadeFrete
    {

        [XmlEnum("0")]
        [Description("Por Conta Remetente")]
        PorContaRemetente = 0,

        [XmlEnum("1")]
        [Description("Por Conta Destinatário")]
        PorContaDestinatario = 1,

        [XmlEnum("2")]
        [Description("Por Conta Terceiros")]
        PorContaTerceiros = 2,

        [XmlEnum("3")]
        [Description("Próprio Conta Remetente")]
        ProprioContaRemetente = 3,

        [XmlEnum("4")]
        [Description("Próprio Conta Destinatário")]
        ProprioContaDestinatario = 4,

        [XmlEnum("9")]
        [Description("Sem Transporte")]
        SemTransporte = 9,
    }
}
