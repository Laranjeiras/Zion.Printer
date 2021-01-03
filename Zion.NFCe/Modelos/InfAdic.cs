using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Zion.NFCe.Modelos
{
    public partial class InfAdic
    {
        public string infAdFisco { get; set; }
        public string infCpl { get; set; }

        [XmlElement("obsCont")]
        public List<ObsCont> obsCont { get; set; }

        [XmlElement("obsFisco")]
        public List<ObsFisco> obsFisco { get; set; }

        public InfAdic()
        {
            obsCont = new List<ObsCont>();
            obsFisco = new List<ObsFisco>();
        }

    }
}
