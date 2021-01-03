using System;
using System.Xml;
using System.Xml.Serialization;
using Zion.NFCe.Enums;

namespace Zion.NFCe.Modelos
{

    [XmlRoot("nfeProc", Namespace = NameSpaces.NFe, IsNullable = false)]
    public class NFeProc
    {
        public NFe NFe { get; set; }

        public ProtNFe protNFe { get; set; }

        [XmlAttribute]
        public string versao { get; set; }
    }

    public class ProdutoICMS
    {
        [XmlElement("ICMS00", typeof(ImpostoICMS00))]
        [XmlElement("ICMS10", typeof(ImpostoICMS10))]
        [XmlElement("ICMS20", typeof(ImpostoICMS20))]
        [XmlElement("ICMS30", typeof(ImpostoICMS30))]
        [XmlElement("ICMS40", typeof(ImpostoICMS40))]
        [XmlElement("ICMS51", typeof(ImpostoICMS51))]
        [XmlElement("ICMS60", typeof(ImpostoICMS60))]
        [XmlElement("ICMS70", typeof(ImpostoICMS70))]
        [XmlElement("ICMS90", typeof(ImpostoICMS90))]
        [XmlElement("ICMSPart", typeof(ImpostoICMSPart))]
        [XmlElement("ICMSSN101", typeof(ImpostoICMSSN101))]
        [XmlElement("ICMSSN102", typeof(ImpostoICMSSN102))]
        [XmlElement("ICMSSN201", typeof(ImpostoICMSSN201))]
        [XmlElement("ICMSSN202", typeof(ImpostoICMSSN202))]
        [XmlElement("ICMSSN500", typeof(ImpostoICMSSN500))]
        [XmlElement("ICMSSN900", typeof(ImpostoICMSSN900))]
        [XmlElement("ICMSST", typeof(ImpostoICMSST))]
        public ImpostoICMS ICMS;
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = NameSpaces.NFe)]
    public class ProdutoIPI
    {
        public string clEnq { get; set; }
        public string CNPJProd { get; set; }
        public string cSelo { get; set; }
        public string qSelo { get; set; }
        public string cEnq { get; set; }
        public IPITrib IPITrib { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = NameSpaces.NFe)]
    public class IPITrib
    {
        public string CST { get; set; }
        public double? pIPI { get; set; }
        public double? qUnid { get; set; }
        public double? vBC { get; set; }
        public double? vUnid { get; set; }
        public double? vIPI { get; set; }
    }
}
