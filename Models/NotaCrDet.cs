using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class NotaCrDet
    {
        public int? NotaCrId { get; set; }
        public int? ArticuloId { get; set; }
        public float? FacturaQty { get; set; }
        public decimal? FacturaPrecio { get; set; }
        public decimal? FacturaItbis { get; set; }
        public int NotaCrDetId { get; set; }
        public bool NotaCrDetSiCant { get; set; }
        public int? UnidadId { get; set; }
        public byte[]? UpsizeTs { get; set; }

        public virtual NotaCr? NotaCr { get; set; }
    }
}
