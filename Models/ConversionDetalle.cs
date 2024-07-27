using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class ConversionDetalle
    {
        public int ConversionDetalleId { get; set; }
        public int? ConversionId { get; set; }
        public int? ArticuloId { get; set; }
        public int? ConversionDetalleCant { get; set; }
        public decimal? ConversionDetallePrecio { get; set; }

        public virtual Conversion? Conversion { get; set; }
    }
}
