using System.Text;
using Zion.NFCe.Modelos;

namespace Zion.NFCe.ViewModels
{
    internal class EmitenteViewModel
    {
        public string Nome { get; private set; }
        public string CpfCnpj { get; private set; }
        public string xCpfCnpj => CpfCnpj.Length == 11 ? $"CPF: {CpfCnpj}" : $"CNPJ: {CpfCnpj}";
        public string EnderecoLogadrouro { get; private set; }
        public string EnderecoComplemento { get; private set; }
        public string EnderecoNumero { get; private set; }
        public string EnderecoCep { get; private set; }
        public string EnderecoBairro { get; private set; }
        public string EnderecoUf { get; private set; }
        public string Municipio { get; private set; }
        public string IE { get; private set; }
        public string Telefone { get; private set; }

        public string EnderecoLinha1
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(EnderecoLogadrouro);
                if (!string.IsNullOrWhiteSpace(EnderecoNumero)) sb.Append(", ").Append(EnderecoNumero);
                if (!string.IsNullOrWhiteSpace(EnderecoComplemento)) sb.Append(" - ").Append(EnderecoComplemento);
                return sb.ToString();
            }
        }

        /// <summary>
        /// Linha 1 do Endereço
        /// </summary>
        public string EnderecoLinha2 => $"{EnderecoBairro} - CEP: {EnderecoCep}";


        /// <summary>
        /// Linha 3 do Endereço
        /// </summary>
        public string EnderecoLinha3
        {
            get
            {
                StringBuilder sb = new StringBuilder()
                    .Append(Municipio).Append(" - ").Append(EnderecoUf);

                if (!string.IsNullOrWhiteSpace(Telefone))
                    sb.Append(" Fone: ").Append(Telefone);

                return sb.ToString();
            }
        }

        public static class Factory
        {
            public static EmitenteViewModel Criar(Empresa empresa)
            {
                Emitente emit = null;
                if (empresa is Emitente)
                    emit = empresa as Emitente;


                var vm = new EmitenteViewModel();

                vm.Nome = emit == null ? empresa.xNome : emit.xFant ?? emit.xNome;
                vm.CpfCnpj = empresa.CNPJ ?? empresa.CPF;
                vm.IE = empresa.IE;

                if (empresa.Endereco != null)
                {
                    vm.EnderecoLogadrouro = empresa.Endereco.xLgr;
                    vm.EnderecoNumero = empresa.Endereco.nro;
                    vm.EnderecoBairro = empresa.Endereco.xBairro;
                    vm.Municipio = empresa.Endereco.xMun;
                    vm.EnderecoUf = empresa.Endereco.UF;
                    vm.EnderecoCep = empresa.Endereco.CEP;
                    vm.EnderecoComplemento = empresa.Endereco.xCpl;
                }
                return vm;
            }
        }
    }
}
