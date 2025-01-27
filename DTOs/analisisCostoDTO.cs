using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class analisisCostoDTO
    {
        public int ArticuloAnalisisCostoId { get; set; }
        public int? ArticuloId { get; set; }
        public double? TotalCosto { get; set; }
        public double? CostoUnd { get; set; }
        public double? Ganancia { get; set; }
        public bool? Estado { get; set; }
        public int? Cantidad { get; set; }
        public double? TotalCostoExist { get; set; }
        public double? TotalCostoFalt { get; set; }
        public string? LabelInfo1 { get; set; }
        public string? LabelInfo2 { get; set; }
    }
}
