using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ReciboPagoDet
    {
        public int? ReciboId { get; set; }
        public int? FacturaId { get; set; }
        public decimal? ReciboFactPagoMonto { get; set; }

        public virtual Factura? Factura { get; set; }
        public virtual ReciboPago? Recibo { get; set; }
    }
}
