using System.Collections.Generic;
using System.Xml.Serialization;
using Zion.NFCe.Enums;

namespace Zion.NFCe.Modelos
{
    public class Pagamento
    {
        [XmlElement("detPag")]
        public List<DetalhePagamento> detPag { get; set; }
        public decimal? vTroco { get; set; }
        public FormaPagamento? tPag { get; set; }
        public decimal? vPag { get; set; }
        public Card card { get; set; }
    }
}
