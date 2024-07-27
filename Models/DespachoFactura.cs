using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class DespachoFactura
    {
        public int DespachoFacturaId { get; set; }
        public DateTime? DespachoFacturaFecha { get; set; }
        public int? FacturaDetId { get; set; }
        public float? FacturaDetCant { get; set; }
        public byte[]? UpsizeTs { get; set; }

        public virtual FacturaDet? FacturaDet { get; set; }
    }
}
