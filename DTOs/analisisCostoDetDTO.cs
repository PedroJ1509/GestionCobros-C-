using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class analisisCostoDetDTO
    {
        public int ArticuloPorKitId { get; set; }
        public int? ArticuloId { get; set; }
        public int UnidadId { get; set; }
        public double? cantidad { get; set; }
        public double? CostoUnidad { get; set; }
        public double? CostoUnidadTotales { get; set; }
        public string TotalCosto { get; set; }
        public double? TotalCostoTotales { get; set; }
        public double? Existencia { get; set; }
        public double? TotalCostoExistencia { get; set; }
        public double? ExistenciaFaltante { get; set; }
        public double? TotalCostoExistenciaFaltante { get; set; }
        public double? TotalCostoExistenciaFaltanteTotales { get; set; }
    }
}
