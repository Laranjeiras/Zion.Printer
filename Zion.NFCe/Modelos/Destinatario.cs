using System.Xml;
using System.Xml.Serialization;

namespace Zion.NFCe.Modelos
{
    public partial class Destinatario : Empresa
    {
        [XmlElement("idEstrageiro")]
        public string IdEstrangeiro { get; set; }

        [XmlElement("enderDest")]
        public override Endereco Endereco { get; set; }
    }
}
