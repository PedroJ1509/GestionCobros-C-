using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class CuotaTipoPago
    {
        public int CuotaId { get; set; }
        public int TipoPagoId { get; set; }
        public int CuotaTipoPagoSec { get; set; }
        public decimal? CuotaTipoPagoMonto { get; set; }
        public string? CuotaTipoPagoCom { get; set; }
        public int? NotaCrId { get; set; }

        public virtual Cuotum Cuota { get; set; } = null!;
        public virtual NotaCr? NotaCr { get; set; }
        public virtual TipoPago TipoPago { get; set; } = null!;
    }
}
