using System.ComponentModel;
using System.Xml.Serialization;

namespace Zion.NFCe.Enums
{
    public enum TipoIntegracaoPagamento
    {
        [Description("Integrado Automação")]
        [XmlEnum("1")]
        IntegradoAutomacao = 1,
        [Description("Não Integrado")]
        [XmlEnum("2")]
        NaoIntegrado = 2
    }
}
