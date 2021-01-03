using System;
using System.Xml.Serialization;

namespace Zion.NFCe.Enums
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = NameSpaces.NFe)]
    public enum TipoEmissao
    {

        [XmlEnum("1")]
        Normal = 1,

        [XmlEnum("2")]
        ContingenciaFS = 2,

        [XmlEnum("3")]
        ContingenciaSCAN = 3,

        [XmlEnum("4")]
        ContingenciaDPEC = 4,

        [XmlEnum("5")]
        ContingenciaFSDA = 5,

        [XmlEnum("6")]
        ContingenciaSVCAN = 6,

        [XmlEnum("7")]
        ContingenciaSVCRS = 7,

        [XmlEnum("9")]
        ContingenciaOffLineNFCe = 9,
    }
}
