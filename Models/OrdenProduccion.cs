using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class OrdenProduccion
    {
        public OrdenProduccion()
        {
            OrdenProduccionArtUsados = new HashSet<OrdenProduccionArtUsado>();
        }

        public int OrdenProduccionId { get; set; }
        public int? OrdenProduccionNo { get; set; }
        public DateTime? OrdenProduccionFecha { get; set; }
        public int? ClienteId { get; set; }
        public int? ArticuloId { get; set; }
        public float? OrdenProduccionCantOrdenada { get; set; }
        public float? OrdenProduccionLargo { get; set; }
        public float? OrdenProduccionAncho { get; set; }
        public float? OrdenProduccionFondo { get; set; }
        public float? OrdenProduccionCantReportada { get; set; }
        public float? OrdenProduccionCantDisponible { get; set; }
        public decimal? OrdenProduccionCosto { get; set; }
        public int? OpestatusId { get; set; }
        public int? AlmacenId { get; set; }
        public bool OrdenProduccionNoAfectaInv { get; set; }
        public int? OrdenProduccionOrden { get; set; }
        public string? OrdenProduccionComentario { get; set; }
        public bool OrdenProduccionSiPospuesto { get; set; }
        public byte[]? UpsizeTs { get; set; }

        public virtual ICollection<OrdenProduccionArtUsado> OrdenProduccionArtUsados { get; set; }
    }
}
