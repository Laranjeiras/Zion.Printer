using System;
using System.Xml.Serialization;

namespace Zion.NFCe.Enums
{
    [Serializable]
    [XmlType(Namespace = NameSpaces.NFe)]
    public enum TipoAmbiente
    {
        [XmlEnum("1")]
        Producao = 1,

        [XmlEnum("2")]
        Homologacao = 2,
    }
}
