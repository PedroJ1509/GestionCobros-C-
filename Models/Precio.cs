using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class Precio
    {
        public int PrecioId { get; set; }
        public int? ArticuloId { get; set; }
        public int? PrecioNo { get; set; }
        public double? PrecioMonto { get; set; }
        public float? PrecioGanancia { get; set; }
        public float? PrecioComision { get; set; }
        public string? PrecioCodigo { get; set; }
        public byte[]? UpsizeTs { get; set; }
    }
}
