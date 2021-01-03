using System.Xml;
using System.Xml.Serialization;

namespace Zion.NFCe.Modelos
{
    public class Detalhe
    {
        public Produto prod { get; set; }
        public ProdutoImposto imposto { get; set; }
        public string infAdProd { get; set; }

        [XmlAttribute]
        public string nItem { get; set; }
    }
}
