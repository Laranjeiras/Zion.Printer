using System;
using System.Text;
using Zion.NFCe.Enums;
using Zion.NFCe.Tools;
using Zion.NFCe.ViewModels;
using Zion.Printer;
using Zion.Printer.Elements.Drawing;
using Zion.Printer.Enums;

namespace Zion.NFCe
{
    public class ImprimirNFCe
    {
        private readonly int FontSize;
        private readonly int LarguraImpressao;
        private readonly ConfigDanfeNFCe config;
        private DanfeViewModel vm;
        protected readonly ZionPrinter printer;

        public ImprimirNFCe(ConfigDanfeNFCe config, string nomeImpressora)
        {
            this.config = config;
            printer = new ZionPrinter(nomeImpressora);
            printer.Printing += Imprimindo;

            FontSize = config.TamanhoFontePadrao <= 0 ? 7 : config.TamanhoFontePadrao;
            LarguraImpressao = config.LarguraImpressao <= 0 ? 282 : config.LarguraImpressao;
        }

        public void Imprimir(string xml)
        {
            var nfeProc = XmlTools.XmlStringParaNFeProc(xml);
            if (nfeProc == null)
                throw new Exception("Ocorreu um erro ao carregar o NFeProc");

            vm = DanfeViewModel.Factory.Criar(nfeProc);
            printer.Print();
        }

        private void Imprimindo(object sender, PrinterTools e)
        {
            e.SetFont(config.FontePadrao);

            e.WriteText(vm.Emitente.Nome, FontSize + 4, Alignment.Center);
            e.WriteText(vm.CpfCnpjInscEst, FontSize + 2, Alignment.Center);
            e.WriteText(vm.Emitente.EnderecoLinha1, FontSize, Alignment.Center);
            e.WriteText(vm.Emitente.EnderecoLinha2, FontSize, Alignment.Center);
            e.WriteText(vm.Emitente.EnderecoLinha3, FontSize, Alignment.Center);
            e.AddRowSpace(3);
            e.DrawHorizontalLine();
            e.WriteText("DANFE NFCe - Documento Auxiliar Da \nNota Fiscal de Consumidor Eletrônica", config.TamanhoFontePadrao + 1, Alignment.Center);
            e.AddRowSpace(3);
            e.DrawHorizontalLine();
            e.AddRowSpace(6);
            MensagemContigencia(e);

            e.WriteColumn("CODIGO", 0, 25, FontSize);
            int sizeDesc = e.WriteColumn("DESCRICAO", 50, 25, FontSize);
            e.AddRowSpace(sizeDesc);
            e.WriteColumn("QTDE", 50, 25, FontSize);
            e.WriteColumn("UN", 100, 25, FontSize);
            e.WriteColumn("X", 120, 25, FontSize);
            e.WriteColumn("VALOR UNITÁRIO", 150, 25, FontSize);
            e.WriteColumn("TOTAL", 280, 25, FontSize, Alignment.Right);
            e.BreakLine();
            e.AddRowSpace(6);

            #region Itens
            foreach (var item in vm.Itens)
            {
                e.WriteColumn(item.Codigo, 1, 50, FontSize);

                var colDesc = e.AddText(item.Descricao, FontSize);
                var colDescQuebra = new LineBreak(colDesc, 227, colDesc.Size.Width);
                colDesc = colDescQuebra.Draw(e.graphics, 50, e.Y);

                e.AddRowSpace(colDesc.Size.Height);

                e.WriteColumn(item.Quantidade.ToString("N2"), 50, 230, FontSize);
                e.WriteColumn(item.Unidade, 100,30, FontSize);
                e.WriteColumn(item.Preco.ToString("N2"), 150, 50, FontSize);
                e.WriteColumn(item.SubTotal.ToString("N2"), LarguraImpressao, 50, FontSize, Alignment.Right);
                e.BreakLine();
                e.AddRowSpace(4);

                // IMPLEMENTAR DESCONTO
            }
            #endregion

            e.DrawHorizontalLine();
            e.BreakLine();

            #region Totais
            e.WriteColumn("QTD. TOTAL DE ITENS:", 0, 100, FontSize);
            e.WriteColumn(vm.QtdTotalItens, LarguraImpressao, 50, FontSize, Alignment.Right);
            e.BreakLine();
            
            if (vm.TotalDesconto > 0)
            {
                e.WriteColumn("SUB TOTAL:", 0, 100, FontSize);
                e.WriteColumn(vm.ValorTotal.ToString("C"), LarguraImpressao, 100, FontSize, Alignment.Right);
                e.BreakLine();

                e.WriteColumn("DESCONTO:", 0, 100, FontSize);
                e.WriteColumn(vm.TotalDesconto.ToString("N2"), LarguraImpressao, 100, FontSize, Alignment.Right);
                e.BreakLine();
            }

            e.WriteColumn("VALOR TOTAL:", 0, 100, FontSize + 1);
            e.WriteColumn(vm.ValorTotal.ToString("C"), LarguraImpressao, 100, FontSize + 1, Alignment.Right);
            e.BreakLine();
            e.AddRowSpace(6);

            e.WriteColumn("FORMA PAGAMENTO:", 0, 100, FontSize);
            e.WriteColumn("VALOR PAGO", LarguraImpressao, 100, FontSize, Alignment.Right);
            e.BreakLine();

            e.AddRowSpace(3);
            foreach (var pagamento in vm.Pagamentos)
            {
                e.WriteColumn(pagamento.FormaPagamento.ToString(), 0, 100, FontSize);
                e.WriteColumn(pagamento.Valor.ToString("C"), LarguraImpressao, 100, FontSize, Alignment.Right);
                e.BreakLine();
            }

            e.AddRowSpace(9);

            if (vm.Troco > 0)
            {
                e.WriteColumn("TROCO", 0, 200, FontSize + 2);
                e.WriteColumn(vm.Troco.ToString("C"), LarguraImpressao, 200, FontSize + 2, Alignment.Right);
                e.BreakLine();
                e.AddRowSpace(9);
            }
            #endregion

            e.DrawHorizontalLine();

            e.WriteText("Consulte pela Chave de Acesso em", FontSize, Alignment.Center);
            e.WriteText(vm.UrlChave, FontSize, Alignment.Center);
            e.AddRowSpace(5);
            e.WriteText("CHAVE DE ACESSO", FontSize, Alignment.Center);
            e.WriteText(FormatarChaveAcesso(vm.ChaveAcesso), FontSize, Alignment.Center);

            e.AddRowSpace(10);

            #region Consumidor
            var consumidor = vm.Destinatario.Consumidor;

            var colConsumidor = e.AddText(consumidor, FontSize + 2);
            if (colConsumidor.Size.Width < LarguraImpressao)
            {
                e.WriteText(consumidor, FontSize + 2, Alignment.Center);
            }
            else
            {
                var colConsQuebra = new LineBreak(colConsumidor, LarguraImpressao, colConsumidor.Size.Width);
                colConsumidor = colConsQuebra.Draw(e.graphics, 0, e.Y);
                e.AddRowSpace(colConsumidor.Size.Height);
            }
            #endregion

            e.AddRowSpace(10);

            e.WriteText(MontarDadosNFCe(), FontSize, Alignment.Center);
            e.WriteText("Via Consumidor", FontSize, Alignment.Center);

            if (vm.TipoEmissao == TipoEmissao.Normal)
            {
                e.WriteText($"Protocolo de autorização: {vm.ProtocoloAutorizacao}", FontSize, Alignment.Center);
                e.WriteText($"Data de autorização: {vm.DataAutorizacao}", FontSize, Alignment.Center);
            }

            e.AddRowSpace(10);
            MensagemContigencia(e);
            e.AddRowSpace(4);

            var qrCodeImagem = QrCode.Gerar(vm.QrCode);
            e.DrawImage(qrCodeImagem, Alignment.Center);

            e.AddRowSpace(5);
            e.WriteColumn("TRIBUTOS INCIDENTES (Lei Federal 12741/2012)", 0, 200, FontSize);
            e.WriteColumn(vm.TributosIncidentes.ToString("C"), LarguraImpressao, 200, FontSize, Alignment.Right);
            e.BreakLine();

            e.AddRowSpace(10);

            var colObs = e.AddText(vm.Observacoes, FontSize);
            var colObsQuebra = new LineBreak(colObs, LarguraImpressao, colObs.Size.Width);
            colObsQuebra.Draw(e.graphics, 0, e.Y);
        }

        private string MontarDadosNFCe()
        {
            var dadosNFCe = new StringBuilder();
            dadosNFCe.Append("NFC-e nº ");
            dadosNFCe.Append(vm.NFNumero.ToString("D9"));
            dadosNFCe.Append(" Série ");
            dadosNFCe.Append(vm.NFSerie.ToString("D3"));
            dadosNFCe.Append(" ");
            dadosNFCe.Append(vm.DataEmissao);
            return dadosNFCe.ToString();
        }

        private string FormatarChaveAcesso(string chaveAcesso)
        {
            if (chaveAcesso == null)
                throw new ArgumentNullException("Chave de Acesso");

            chaveAcesso = chaveAcesso.Replace("NFe", string.Empty);

            string novaChave = string.Empty;

            for (int i = 0; i < chaveAcesso.Length; i += 4)
                novaChave += $"{chaveAcesso.Substring(i, 4)} ";

            return novaChave.Trim();
        }

        private void MensagemContigencia(PrinterTools e)
        {
            if (vm.TipoEmissao != TipoEmissao.Normal)
            {
                e.WriteText("EMITIDA EM CONTINGÊNCIA", FontSize + 3, Alignment.Center);
                e.WriteText("Pendente de Autorização", FontSize, Alignment.Center);
                e.AddRowSpace(6);
                e.DrawHorizontalLine();
            }
        }
    }
}
