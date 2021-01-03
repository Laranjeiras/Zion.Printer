using System.Xml;
using System.Xml.Serialization;
using Zion.NFCe.Enums;
using Zion.NFCe.Structs;

namespace Zion.NFCe.Modelos
{
    public class InfProt
    {
        public TipoAmbiente tpAmb { get; set; }

        public string verAplic { get; set; }
        public string chNFe { get; set; }

        public DateTimeOffsetIso8601 dhRecbto { get; set; }

        public string nProt { get; set; }
        public int cStat { get; set; }
        public string xMotivo { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }
    }
}
