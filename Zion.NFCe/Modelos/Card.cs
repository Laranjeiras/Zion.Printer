using Zion.NFCe.Enums;

namespace Zion.NFCe.Modelos
{
    public class Card
    {
        public TipoIntegracaoPagamento? tpIntegra { get; set; }
        public string CNPJ { get; set; }
        public BandeiraCartao? tBand { get; set; }
        public string cAut { get; set; }
    }
}
