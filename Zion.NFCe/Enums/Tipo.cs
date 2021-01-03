using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Zion.NFCe.Enums
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = NameSpaces.NFe)]
    public enum Tipo
    {

        [XmlEnum("0")]
        [Description("Entrada")]
        Entrada = 0,
        [XmlEnum("1")]
        [Description("Saída")]
        Saida = 1
    }
}
