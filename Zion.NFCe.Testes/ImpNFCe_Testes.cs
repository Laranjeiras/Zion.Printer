using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using Zion.NFCe.Tools;

namespace Zion.NFCe_Testes
{
    [TestClass]
    public class ImpNFCe_Testes
    {
        [TestMethod]
        public void Imprimir()
        {            
            var path = @"C:\Zion.NFCe\XMls";

            var imp = new NFCe.ImprimirNFCe(new NFCe.ConfigDanfeNFCe("Microsoft Sans Serif", 7), "EPSON TM-T20 ReceiptE4 (1)");

            var files = Directory.GetFiles(path);
            foreach (var file in files.OrderByDescending(x=>x.Length))
            {
                var xml = XmlTools.CarregarXmlStringDeArquivo(file);                
                imp.Imprimir(xml);
                return;
            }
        }
    }
}
