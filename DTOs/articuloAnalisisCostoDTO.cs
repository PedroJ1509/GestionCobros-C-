using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class articuloAnalisisCostoDTO
    {
        public int ArticuloAnalisisCostoId { get; set; }
        public DateTime? Fecha { get; set; }
        public int? ArticuloId { get; set; }
        public double? TotalCosto { get; set; }
        public double? CostoUnidad { get; set; }
        public double? Ganancia { get; set; }
        public double? Precio { get; set; }
        public bool? EstadoCerrada { get; set; }
        public double? CantidadTotal { get; set; }
    }
}
