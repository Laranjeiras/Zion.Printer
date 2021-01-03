using System;
using System.Xml.Serialization;
using Zion.NFCe.Enums;

namespace Zion.NFCe.Modelos
{
    public class ImpostoICMS
    {
        public string orig { get; set; }
        public string CST { get; set; }
        public string CSOSN { get; set; }
        public double vBC { get; set; }
        public double pICMS { get; set; }
        public double vICMS { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = NameSpaces.NFe)]
    public partial class ICMSTotal
    {
        public double vBC { get; set; }

        public double vICMS { get; set; }

        public double? vICMSUFDest { get; set; }

        public double? vICMSUFRemet { get; set; }

        public double? vFCPUFDest { get; set; }

        public double vBCST { get; set; }

        public double vST { get; set; }

        public double vProd { get; set; }

        public double vFrete { get; set; }

        public double vSeg { get; set; }

        public double vDesc { get; set; }

        public double vII { get; set; }

        public double vIPI { get; set; }

        public double vPIS { get; set; }

        public double vCOFINS { get; set; }

        public double vOutro { get; set; }

        public double vNF { get; set; }

        public decimal? vTotTrib { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = NameSpaces.NFe)]
    public partial class ISSQNTotal
    {
        public double? vServ { get; set; }
        public double? vBC { get; set; }
        public double? vISS { get; set; }
        public double? vPIS { get; set; }
        public double? vCOFINS { get; set; }
    }


    public class ImpostoICMS00 : ImpostoICMS { }
    public class ImpostoICMS10 : ImpostoICMS { }
    public class ImpostoICMS20 : ImpostoICMS { }
    public class ImpostoICMS30 : ImpostoICMS { }
    public class ImpostoICMS40 : ImpostoICMS { }
    public class ImpostoICMS51 : ImpostoICMS { }
    public class ImpostoICMS60 : ImpostoICMS { }
    public class ImpostoICMS70 : ImpostoICMS { }
    public class ImpostoICMS90 : ImpostoICMS { }
    public class ImpostoICMSPart : ImpostoICMS { }
    public class ImpostoICMSSN101 : ImpostoICMS { }
    public class ImpostoICMSSN102 : ImpostoICMS { }
    public class ImpostoICMSSN201 : ImpostoICMS { }
    public class ImpostoICMSSN202 : ImpostoICMS { }
    public class ImpostoICMSSN500 : ImpostoICMS { }
    public class ImpostoICMSSN900 : ImpostoICMS { }
    public class ImpostoICMSST : ImpostoICMS { }
}
