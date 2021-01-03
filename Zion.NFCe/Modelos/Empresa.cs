using System.Xml.Serialization;

namespace Zion.NFCe.Modelos
{
    public class Empresa
    {
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string xNome { get; set; }
        public string IE { get; set; }
        public string IEST { get; set; }
        public string email { get; set; }

        [XmlIgnore]
        public virtual Endereco Endereco { get; set; }
    }
}
