using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class OrdenCompraDet
    {
        public int OrdenCompraDetId { get; set; }
        public int? OrdenCompraId { get; set; }
        public int? ArticuloId { get; set; }
        public string? OrdenCompraDetArticulo { get; set; }
        public float? OrdenCompraDetQty { get; set; }
        public decimal? OrdenCompraDetCosto { get; set; }
        public decimal? OrdenCompraDetItbis { get; set; }
        public string? OrdenCompraDetComentario { get; set; }
        public int? UnidadId { get; set; }
        public bool? OrdenCompraDetSiItbisinc { get; set; }

        public virtual OrdenCompra? OrdenCompra { get; set; }
    }
}
