namespace Zion.NFCe.ViewModels
{
    internal class ItemViewModel
    {
        public string nItem { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal SubTotal { get; set; }
    }
}
