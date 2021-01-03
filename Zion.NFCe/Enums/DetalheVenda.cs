using System.ComponentModel;

namespace Zion.NFCe.Enums
{
    public enum DetalheVendaNormal
    {
        [Description("Não Imprimir")]
        NaoImprimir = 0,
        [Description("Uma Linha")]
        UmaLinha = 1,
        [Description("Duas Linhas")]
        DuasLinhas = 2
    }

    public enum DetalheVendaContigencia
    {
        [Description("Uma Linha")]
        UmaLinha = 1,
        [Description("Duas Linhas")]
        DuasLinhas = 2
    }
}
