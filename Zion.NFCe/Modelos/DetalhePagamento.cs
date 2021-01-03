using Zion.NFCe.Enums;

namespace Zion.NFCe.Modelos
{
    public class DetalhePagamento
    {
        public IndicadorPagamento? indPag { get; set; }
        public FormaPagamento tPag { get; set; }
        public decimal vPag { get; set; }
        public Card card { get; set; }
    }
}
