using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class OrdenProduccionTemp
    {
        public int OrdenProduccionTempId { get; set; }
        public int? OrdenProduccionTempNo { get; set; }
        public DateTime? OrdenProduccionTempFecha { get; set; }
        public int? ClienteId { get; set; }
        public int? ArticuloId { get; set; }
        public float? OrdenProduccionTempCantOrdenada { get; set; }
        public float? OrdenProduccionTempLargo { get; set; }
        public float? OrdenProduccionTempAncho { get; set; }
        public float? OrdenProduccionTempFondo { get; set; }
        public decimal? OrdenProduccionTempCosto { get; set; }
        public string? Computadora { get; set; }
        public byte[]? UpsizeTs { get; set; }
    }
}
