using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class SuplidorArticulo
    {
        public int SuplidorId { get; set; }
        public int ArticuloId { get; set; }
        public decimal? SuplidorArticulosUltimoCosto { get; set; }
        public string? SuplidorArticulosPartNo { get; set; }

        public virtual Suplidor Suplidor { get; set; } = null!;
    }
}
