using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class OrdenProduccionArtUsado
    {
        public int OrdenProduccionArtUsadoId { get; set; }
        public int? OrdenProduccionId { get; set; }
        public int? ArticuloId { get; set; }
        public int? AlmacenId { get; set; }
        public double? OrdenProduccionArtUsadoCant { get; set; }
        public byte[]? UpsizeTs { get; set; }

        public virtual Almacen? Almacen { get; set; }
        public virtual OrdenProduccion? OrdenProduccion { get; set; }
    }
}
