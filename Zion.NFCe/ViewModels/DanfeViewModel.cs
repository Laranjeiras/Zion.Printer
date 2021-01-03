using System;
using System.Collections.Generic;
using System.Linq;
using Zion.NFCe.Enums;
using Zion.NFCe.Modelos;
using Zion.NFCe.Tools;

namespace Zion.NFCe.ViewModels
{
    internal class DanfeViewModel
    {
        public string CpfCnpjInscEst => !string.IsNullOrEmpty(Emitente.IE) ? $"{Emitente.xCpfCnpj}  IE: {Emitente.IE}" : $"{Emitente.xCpfCnpj}";

        public string ChaveAcesso { get; private set; }
        public int NFNumero { get; private set; }
        public int NFSerie { get; private set; }
        public string DataEmissao { get; private set; }

        public TipoEmissao TipoEmissao { get; private set; }
        public Tipo TipoNF { get; private set; }

        public string ProtocoloAutorizacao { get; private set; }
        public string DataAutorizacao { get; private set; }

        public EmitenteViewModel Emitente { get; private set; }
        public DestinatarioViewModel Destinatario { get; private set; }

        public IList<ItemViewModel> Itens { get; private set; } = new List<ItemViewModel>();
        public IList<PagamentoViewModel> Pagamentos { get; private set; } = new List<PagamentoViewModel>();

        public string QtdTotalItens => Itens.Count().ToString("N0");
        public decimal ValorTotal => Itens.Sum(x => x.SubTotal);
        public decimal TotalDesconto => Itens.Sum(x => x.Desconto);
        public decimal TotalPago => Pagamentos.Sum(x => x.Valor);
        public decimal Troco => TotalPago - ValorTotal;
        public decimal TributosIncidentes { get; private set; }

        public string UrlChave { get; private set; }
        public string QrCode { get; private set; }
        public string Observacoes { get; private set; }
        
        public static class Factory
        {
            private readonly static IEnumerable<TipoEmissao> FormasEmissaoSuportadas =
                new TipoEmissao[] {
                    TipoEmissao.Normal,
                    TipoEmissao.ContingenciaOffLineNFCe
                };

            public static DanfeViewModel Criar(NFeProc nfeProc)
            {
                DanfeViewModel vm = new DanfeViewModel();

                var nfe = nfeProc.NFe;
                var infNfe = nfe.infNFe;
                var ide = infNfe.ide;
                vm.TipoEmissao = ide.tpEmis;

                if (ide.mod != 65)
                    throw new NotSupportedException("Modelo não implementado");

                if (!FormasEmissaoSuportadas.Contains(vm.TipoEmissao))
                    throw new NotSupportedException($"Tipo de emissão [{ide.tpEmis}] não é suportado.");

                if (vm.TipoEmissao == TipoEmissao.Normal)
                {
                    var infProt = nfeProc.protNFe.infProt;
                    vm.ProtocoloAutorizacao = infProt.nProt;
                    vm.DataAutorizacao = infProt?.dhRecbto.ToString("G");
                }

                vm.NFNumero = ide.nNF;
                vm.NFSerie = ide.serie;
                vm.ChaveAcesso = nfeProc.NFe.infNFe.Id.Substring(3);
                vm.DataEmissao = nfeProc.NFe.infNFe.ide.dhEmi?.ToString("G");
                vm.TipoNF = ide.tpNF;

                vm.UrlChave = nfeProc.NFe.infNFeSupl.urlChave;
                vm.QrCode = nfeProc.NFe.infNFeSupl.qrCode;

                vm.Emitente = EmitenteViewModel.Factory.Criar(infNfe.emit);

                vm.Destinatario =  DestinatarioViewModel.Factory.Criar(infNfe.dest);

                #region Itens
                vm.Itens = new List<ItemViewModel>();
                foreach (var item in nfeProc.NFe.infNFe.det)
                {
                    var ivm = new ItemViewModel
                    {
                        nItem = item.nItem,
                        Codigo = item.prod.cProd,
                        Descricao = item.prod.xProd,
                        Unidade = item.prod.uCom,
                        Preco = item.prod.vUnCom,
                        Desconto = item.prod.vDesc,
                        Quantidade = item.prod.qCom,
                        SubTotal = item.prod.vProd
                    };
                    vm.Itens.Add(ivm);
                }
                #endregion

                #region Pagamentos
                foreach (var pag in nfeProc.NFe.infNFe.pag)
                {
                    if (pag.detPag == null)
                        continue;

                    foreach (var detPag in pag.detPag)
                    {
                        vm.Pagamentos.Add(
                            new PagamentoViewModel
                            {
                                FormaPagamento = detPag.tPag.Description(),
                                Valor = detPag.vPag
                            }
                        );
                    }
                }
                #endregion

                vm.TributosIncidentes = nfeProc.NFe.infNFe.total.ICMSTot.vTotTrib ?? 0;

                //vm.Observacoes = nfe.infNFe?.infAdic?.infCpl;
                vm.Observacoes = " is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum";
                return vm;
            }
        }
    }
}
