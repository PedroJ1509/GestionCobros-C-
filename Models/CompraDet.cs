using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class CompraDet
    {
        public int CompraId { get; set; }
        public int CompraDetId { get; set; }
        public int? ArticuloId { get; set; }
        public decimal? CompraPrecio { get; set; }
        public float? CompraQty { get; set; }
        public decimal? CompraItbis { get; set; }
        public float? CompraQtyDev { get; set; }
        public string? CompraComentario { get; set; }
        public decimal? CompraCostoAnt { get; set; }
        public bool CompraSiCambioCosto { get; set; }
        public bool CompraSiItbisinc { get; set; }
        public int? CompraDetNo { get; set; }
        public decimal? CompraDetMontoGp { get; set; }
        public int? UnidadId { get; set; }
        public DateTime? ArticuloFechaVenc { get; set; }

        public virtual Articulo? Articulo { get; set; }
        public virtual Compra Compra { get; set; } = null!;
    }
}
