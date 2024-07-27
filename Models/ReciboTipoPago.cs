using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ReciboTipoPago
    {
        public int? ReciboId { get; set; }
        public int? TipoPagoId { get; set; }
        public int ReciboSec { get; set; }
        public decimal? ReciboTipoPagoMonto { get; set; }
        public string? ReciboTipoPagoCom { get; set; }
        public int? NotaCrId { get; set; }

        public virtual ReciboPago? Recibo { get; set; }
        public virtual TipoPago? TipoPago { get; set; }
    }
}
