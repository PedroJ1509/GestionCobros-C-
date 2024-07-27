using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class DistribuirFactura
    {
        public int DistribuirFacturaId { get; set; }
        public int? FacturaId { get; set; }
        public DateTime? DistribuirFacturaFecha { get; set; }
        public decimal? DistribuirFacturaMonto { get; set; }
        /// <summary>
        /// Yes=Debe, No=Pago
        /// </summary>
        public bool DistribuirFacturaEstatus { get; set; }

        public virtual Factura? Factura { get; set; }
    }
}
