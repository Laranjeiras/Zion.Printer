using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using Zion.NFCe.Modelos;

namespace Zion.NFCe.Tools
{
    public static class XmlTools
    {
        public static string CarregarXmlStringDeArquivo(string caminhoArquivo)
        {
            string xmlString = File.ReadAllText(caminhoArquivo);
            return xmlString;
        }

        private static T CarregarDeXmlString<T>(string xmlString) where T : class
        {
            var novaString = ObterNodeDeStringXml(typeof(T).Name, xmlString);
            return XmlStringParaClasse<T>(novaString);
        }

        public static NFeProc XmlStringParaNFeProc(string xml)
        {
            NFeProc nfeProc = null;

            object retorno = CarregarClasse<NFeProc>(xml);
            if (retorno == null)
                retorno = CarregarClasse<NFe>(xml);

            if (retorno == null)
                throw new Exception("Formato de XML inválido");

            if (retorno is NFeProc proc)
                nfeProc = proc;
            else
            {
                nfeProc = new NFeProc
                {
                    NFe = (NFe)retorno
                };
            }
            return nfeProc;
        }

        private static T CarregarClasse<T>(string xml) where T : class
        {
            try
            {
                var retorno = XmlTools.CarregarDeXmlString<T>(xml);
                return retorno;
            }
            catch
            {
                return null;
            }
        }

        private static T XmlStringParaClasse<T>(string input) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));

            try
            {
                T nfe = null;

                using (TextReader reader = new StringReader(input))
                    nfe = (T)serializer.Deserialize(reader);

                return nfe;
            }
            catch (InvalidOperationException e)
            {
                throw new Exception("Não foi possível interpretar o texto Xml.", e);
            }
        }

        private static string ObterNodeDeStringXml(string nomeDoNode, string stringXml)
        {
            var s = stringXml;
            var xmlDoc = XDocument.Parse(s);
            var xmlString = (from d in xmlDoc.Descendants()
                             where d.Name.LocalName.ToLower() == nomeDoNode.ToLower()
                             select d).FirstOrDefault();

            if (xmlString == null)
                throw new Exception(String.Format("Nenhum objeto {0} encontrado no xml!", nomeDoNode));
            return xmlString.ToString();
        }
    }
}
