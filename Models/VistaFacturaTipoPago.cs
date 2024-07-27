using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class VistaFacturaTipoPago
    {
        public int FacturaId { get; set; }
        public string? FacturaNo { get; set; }
        public int? CondPagoId { get; set; }
        public DateTime? FacturaFecha { get; set; }
        public string TipoPago { get; set; } = null!;
    }
}
