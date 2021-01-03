using System.Xml;
using System.Xml.Serialization;

namespace Zion.NFCe.Modelos
{
    public partial class ObsCont
    {
        public string xTexto { get; set; }

        [XmlAttribute]
        public string xCampo { get; set; }
    }
}
