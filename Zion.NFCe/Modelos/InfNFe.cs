using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Zion.NFCe.Modelos
{
    public class InfNFe
    {
        [XmlAttribute]
        public string versao { get; set; }

        [XmlAttribute(DataType = "ID")]
        public string Id { get; set; }

        public Identificacao ide { get; set; }
        public Emitente emit { get; set; }
        public Destinatario dest { get; set; }
        public LocalEntregaRetirada retirada { get; set; }
        public LocalEntregaRetirada entrega { get; set; }

        [XmlElement("det")]
        public List<Detalhe> det { get; set; } = new List<Detalhe>();

        [XmlElement("pag")]
        public List<Pagamento> pag { get; set; }

        public Total total { get; set; }
        public Transporte transp { get; set; }
        public Cobranca cobr { get; set; }
        public InfAdic infAdic { get; set; }
        public InfCompra compra { get; set; }

        [XmlIgnore]
        public string Versao { get; set; }
    }
}
