using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Zion.NFCe.Enums;

namespace Zion.NFCe.Modelos
{
    public class Transporte
    {
        public ModalidadeFrete modFrete { get; set; }
        public Transportador transporta { get; set; }

        public string balsa { get; set; }
        public string vagao { get; set; }

        public Veiculo reboque { get; set; }
        public Veiculo veicTransp { get; set; }

        [XmlElement("vol")]
        public List<Volume> vol { get; set; }

        public Transporte()
        {
            vol = new List<Volume>();
        }
    }
}
