using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class RecGasto
    {
        public RecGasto()
        {
            ChequeGastos = new HashSet<ChequeGasto>();
            EfectivoGastos = new HashSet<EfectivoGasto>();
        }

        public int RecGastoId { get; set; }
        public string? RecGastoNo { get; set; }
        public DateTime? RecGastoFecha { get; set; }
        public int? SuplidorId { get; set; }
        public int? CondPagoId { get; set; }
        public int? GastoId { get; set; }
        public decimal? RecGastoMonto { get; set; }
        public decimal? RecGastoDescto { get; set; }
        public decimal? RecGastoItbis { get; set; }
        public string? RecGastoComentario { get; set; }
        /// <summary>
        /// Yes = No pagada, No = Pagada con cheque
        /// </summary>
        public bool RecGastoEstatus { get; set; }
        public bool RecGastoSiBeneficio { get; set; }
        public string? RecGastoNcf { get; set; }
        public decimal? RecGastoItbisretenido { get; set; }
        public int? ComprobanteTipoId { get; set; }
        public decimal? RecGastoItbisNcnd { get; set; }
        public decimal? RecGastoMontoNcnd { get; set; }

        public virtual ICollection<ChequeGasto> ChequeGastos { get; set; }
        public virtual ICollection<EfectivoGasto> EfectivoGastos { get; set; }
    }
}
