using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class articuloAnalisisCostoDetDTO
    {
        public int ArticuloPorKitId { get; set; }
        public int? ArticuloId { get; set; }
        public string ArticuloDesc { get; set; }
        public string UnidadDesc { get; set; }
        public string cantidad { get; set; }
        public string CostoUnidad { get; set; }
        public double? CostoUnidadTotales { get; set; }
        public string TotalCosto { get; set; }
        public double? TotalCostoTotales { get; set; }
        public string Existencia { get; set; }
        public string TotalCostoExistencia { get; set; }
        public string ExistenciaFaltante { get; set; }
        public string TotalCostoExistenciaFaltante { get; set; }
        public double? TotalCostoExistenciaFaltanteTotales { get; set; }
    }
}
