using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class VistaEstadoSuplidor
    {
        public string? CompraNo { get; set; }
        public DateTime? FechaCompra { get; set; }
        public DateTime? FechaApaga { get; set; }
        public string? SuplidorCd { get; set; }
        public string? Suplidor { get; set; }
        public decimal? Balance { get; set; }
        public decimal? Pagado { get; set; }
        public decimal? Pendiente { get; set; }
    }
}
