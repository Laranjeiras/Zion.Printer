using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Zion.NFCe.Modelos
{
    public partial class Cobranca
    {
        public Fatura fat { get; set; }

        [XmlElement("dup")]
        public List<Duplicata> dup { get; set; }
        public Cobranca()
        {
            dup = new List<Duplicata>();
        }
    }
}
