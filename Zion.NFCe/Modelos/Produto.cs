using System;
using System.Xml.Serialization;
using Zion.NFCe.Enums;

namespace Zion.NFCe.Modelos
{
    public class Produto
    {
        public string cProd { get; set; }
        public string cEAN { get; set; }
        public string xProd { get; set; }
        public string NCM { get; set; }
        public string EXTIPI { get; set; }
        public int CFOP { get; set; }
        public string uCom { get; set; }
        public decimal qCom { get; set; }
        public decimal vUnCom { get; set; }
        public decimal vProd { get; set; }
        public string cEANTrib { get; set; }
        public string uTrib { get; set; }
        public string qTrib { get; set; }
        public string vUnTrib { get; set; }
        public string vFrete { get; set; }
        public string vSeg { get; set; }
        public decimal vDesc { get; set; }
        public string vOutro { get; set; }
        public string xPed { get; set; }
        public string nItemPed { get; set; }
        public string nFCI { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = NameSpaces.NFe)]
    public partial class ProdutoImposto
    {
        public string vTotTrib { get; set; }
        public ProdutoICMS ICMS { get; set; }
        public ProdutoIPI IPI { get; set; }
    }
}
