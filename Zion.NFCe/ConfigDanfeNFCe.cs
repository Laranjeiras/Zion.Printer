namespace Zion.NFCe
{
    public class ConfigDanfeNFCe
    {
        public ConfigDanfeNFCe(string fontePadrao, int tamanhoFontePadrao, int larguraImpressao = 282)
        {
            FontePadrao = fontePadrao;
            TamanhoFontePadrao = tamanhoFontePadrao;
            LarguraImpressao = larguraImpressao;
        }

        public int TamanhoFontePadrao { get; }
        public int LarguraImpressao { get; }
        public string FontePadrao { get; }
    }
}
