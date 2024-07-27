using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class NotaDbDet
    {
        public int? NotaDbId { get; set; }
        public int? ArticuloId { get; set; }
        public float? CompraQty { get; set; }
        public decimal? CompraPrecio { get; set; }
        public decimal? CompraItbis { get; set; }
        public int NotaDbDetId { get; set; }
        public bool NotaDbDetSiCant { get; set; }
        public int? UnidadId { get; set; }
        public byte[]? UpsizeTs { get; set; }

        public virtual NotaDb? NotaDb { get; set; }
    }
}
