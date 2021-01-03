using System;
using Zion.NFCe.Enums;
using Zion.NFCe.Structs;

namespace Zion.NFCe.Modelos
{
    public class Identificacao
    {
        public string natOp { get; set; }
        public int mod { get; set; }
        public short serie { get; set; }
        public int nNF { get; set; }
        public DateTime? dEmi { get; set; }


        #region DataHora Emissão e Saída v2-

        /// <summary>
        /// Data de Saída/Entrada, NFe2
        /// </summary>
        public DateTime? dSaiEnt { get; set; }

        /// <summary>
        /// Hora de Saída/Entrada, NFe2
        /// </summary>
        public string hSaiEnt { get; set; }

        #endregion

        #region DataHora Emissão e Saída v3+

        //public DateTimeOffsetIso8601? dhEmi { get; set; }
        public DateTime? dhEmi { get; set; }

        public DateTime? dhSaiEnt { get; set; }

        #endregion

        public Tipo tpNF { get; set; }
        public int tpImp { get; set; }
        public TipoEmissao tpEmis { get; set; }
        public TipoAmbiente tpAmb { get; set; }

        public DateTimeOffsetIso8601? dhCont { get; set; }
        public string xJust { get; set; }
    }
}
