using System.Text;
using Zion.NFCe.Modelos;

namespace Zion.NFCe.ViewModels
{
    public class DestinatarioViewModel
    { 
        public virtual string Consumidor { get; set; }

        public static class Factory
        {
            public static DestinatarioViewModel Criar(Destinatario dest)
            {
                var vm = new DestinatarioViewModel();

                StringBuilder consumidor = new StringBuilder("CONSUMIDOR ");

                if (dest == null)
                {
                    consumidor.Append("NÃO IDENTIFICADO");
                    vm.Consumidor = consumidor.ToString();
                    return vm;
                }

                consumidor.Append(!string.IsNullOrEmpty(dest.IdEstrangeiro) ? $"Id: {dest.IdEstrangeiro} " : string.Empty);
                consumidor.Append(!string.IsNullOrEmpty(dest.CNPJ) ? $"CNPJ: {dest.CNPJ} " : string.Empty);
                consumidor.Append(!string.IsNullOrEmpty(dest.CPF) ? $"CPF: {dest.CPF} " : string.Empty);
                consumidor.Append(!string.IsNullOrEmpty(dest.xNome) ? $"Nome: {dest.xNome} " : string.Empty);

                var endereco = dest.Endereco;

                if(endereco != null)
                {
                    consumidor.Append(!string.IsNullOrEmpty(endereco.xLgr) ? $"Rua: {endereco.xLgr} " : string.Empty);
                    consumidor.Append(!string.IsNullOrEmpty(endereco.nro) ? $"{endereco.nro}, " : "S/N");
                    consumidor.Append(!string.IsNullOrEmpty(endereco.xBairro) ? $"Bairro: {endereco.xBairro}, " : string.Empty);
                    consumidor.Append(!string.IsNullOrEmpty(endereco.xMun) ? $"{endereco.xMun} " : string.Empty);
                    consumidor.Append(!string.IsNullOrEmpty(endereco.UF) ? $"- {endereco.UF} " : string.Empty);
                    consumidor.Append(!string.IsNullOrEmpty(endereco.CEP) ? $"{endereco.CEP} " : string.Empty);
                }

                vm.Consumidor = consumidor.ToString().Replace(", ,", ", ");
                return vm;
            }
        }
    }
}
