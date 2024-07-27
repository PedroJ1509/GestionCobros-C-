using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JaMPeApp.DTOs
{
    public class precioDTO
    {
        public int PrecioId { get; set; }
        public int? ArticuloId { get; set; }
        public int? PrecioNo { get; set; }
        public double? PrecioMonto { get; set; }
        public float? PrecioGanancia { get; set; }
        public float? PrecioComision { get; set; }
        public string PrecioCodigo { get; set; }
    }
}
