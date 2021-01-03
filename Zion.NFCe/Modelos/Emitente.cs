using System.Xml;
using System.Xml.Serialization;

namespace Zion.NFCe.Modelos
{
    public class Emitente : Empresa
    {
        public string xFant { get; set; }
        public string IM { get; set; }
        public string CNAE { get; set; }

        [XmlElement("enderEmit")]
        public override Endereco Endereco { get; set; }
        public string CRT { get; set; }
    }
}
