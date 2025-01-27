using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class CotizacionDet
    {
        public int CotizacionId { get; set; }
        public int CotizacionDetId { get; set; }
        public int? ArticuloId { get; set; }
        public float? CotizacionQty { get; set; }
        public decimal? CotizacionPrecio { get; set; }
        public decimal? CotizacionItbis { get; set; }
        public string? CotizacionComentario { get; set; }
        public string? CotizacionComentarioMemo { get; set; }
        public int? UnidadId { get; set; }
        public int? OrdenProduccionId { get; set; }
        public int? CotizacionDetNo { get; set; }

        public virtual Cotizacion Cotizacion { get; set; } = null!;
    }
}
