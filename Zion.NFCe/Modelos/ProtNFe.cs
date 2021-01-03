using System.Xml;
using System.Xml.Serialization;

namespace Zion.NFCe.Modelos
{
    public partial class ProtNFe
    {
        public InfProt infProt { get; set; }

        [XmlAttribute]
        public string versao { get; set; }
    }
}
