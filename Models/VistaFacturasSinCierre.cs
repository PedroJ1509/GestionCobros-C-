using System;
using System.Collections.Generic;

namespace JaMPeApp.Models
{
    public partial class VistaFacturasSinCierre
    {
        public int FacturaId { get; set; }
        public string? FacturaNo { get; set; }
        public DateTime? FacturaFecha { get; set; }
        public string? ClienteNombre { get; set; }
        public string? CondPagoDesc { get; set; }
        public decimal? FacturaDescto { get; set; }
        public decimal? FacturaItbis { get; set; }
        public decimal? FacturaMontoImpuesto { get; set; }
        public decimal? FacturaBalance { get; set; }
        public bool FacturaEstatus { get; set; }
    }
}
